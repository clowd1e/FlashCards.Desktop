﻿using FlashCards.Desktop.Extensions;
using FlashCards.Desktop.Models;
using FlashCards.Desktop.RepositoryContracts;

namespace FlashCards.Desktop.Repositories
{
	public class ListCardRepository : ILocalCardRepository
	{
		private readonly int _maxResponseQuality;
		private List<Flashcard> _localFlashcardRepository = [];

        public ListCardRepository(int maxResponseQuality = 5)
        {
            _maxResponseQuality = maxResponseQuality;
        }

        public async Task CreateCard(Flashcard flashcard)
		{
			flashcard.CardId = Guid.NewGuid();

			_localFlashcardRepository.Add(flashcard);

			await Task.CompletedTask;
		}

		public async Task DeleteCard(Guid id)
		{
			_localFlashcardRepository.RemoveAll(temp => temp.CardId == id);

			await Task.CompletedTask;
		}

		public async Task<IEnumerable<Flashcard>?> GetAllCards()
		{
			return await Task.FromResult(_localFlashcardRepository);
		}

		public async Task<Flashcard?> GetCardById(Guid id)
		{
			return await Task.FromResult(_localFlashcardRepository.FirstOrDefault(temp => temp.CardId == id));
		}

		public async Task<IEnumerable<Flashcard>?> GetCardsToReview()
		{
			return await Task.FromResult( _localFlashcardRepository.Where(temp => temp.NextRepeatDate <= DateTime.Now.ToDateOnly()));
		}

		public async Task ResetRepository(List<Flashcard> flashcards)
		{
			_localFlashcardRepository = flashcards;

			await Task.CompletedTask;
		}

		public async Task ReviewCard(Guid cardId, int responseQuality)
		{
			var card = await GetCardById(cardId);

			card.RepetitionCount++;

			await UpdateInterRepetitionInterval(card);
			await UpdateEFactor(card, responseQuality);

			if (responseQuality < 3)
			{
				card.RepetitionCount = 0;
				card.NextRepeatDate = DateTime.Now.ToDateOnly();
			}
		}

		public async Task UpdateCard(Guid id, string mainSide, string oppositeSide)
		{
			var card = await GetCardById(id);

			card.MainSide = mainSide;
			card.OppositeSide = oppositeSide;

			await Task.CompletedTask;
		}

		private async Task UpdateEFactor(Flashcard flashcard, int responseQuality)
		{
			float newEFactor = flashcard.EFactor + (0.1f - (_maxResponseQuality - responseQuality) * (0.08f + (_maxResponseQuality - responseQuality) * 0.02f));

			flashcard.EFactor = Math.Max(1.3f, newEFactor);

			await Task.CompletedTask;
		}

		private async Task UpdateInterRepetitionInterval(Flashcard flashcard)
		{
			if (flashcard.RepetitionCount == 1)
			{
				flashcard.NextRepeatDate = DateTime.Now.AddDays(1).ToDateOnly();
			}
			else if (flashcard.RepetitionCount == 2)
			{
				flashcard.NextRepeatDate = DateTime.Now.AddDays(6).ToDateOnly();
			}
			else
			{
				DateTime currentDate = DateTime.Now;
				DateTime nextRepeatDateTime = DateTime.Parse(flashcard.NextRepeatDate.ToString());

				TimeSpan timeDifference = nextRepeatDateTime - currentDate;

				double daysToAdd = timeDifference.TotalDays * flashcard.EFactor;

				flashcard.NextRepeatDate = currentDate.AddDays(daysToAdd).ToDateOnly();
			}

			await Task.CompletedTask;
		}
	}
}
