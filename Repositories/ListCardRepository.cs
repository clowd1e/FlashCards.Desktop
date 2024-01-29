using FlashCards.Desktop.Extensions;
using FlashCards.Desktop.Models;
using FlashCards.Desktop.RepositoryContracts;

namespace FlashCards.Desktop.Repositories
{
	public class ListCardRepository : IRepository<Flashcard>, ILocalCardRepository
	{
		private readonly List<Flashcard> _localFlashcardRepository = [];
		private readonly int _maxResponseQuality;

        public ListCardRepository(int maxResponseQuality = 5)
        {
            _maxResponseQuality = maxResponseQuality;
        }

        public async Task Create(Flashcard flashcard)
		{
			flashcard.Id = Guid.NewGuid();

			_localFlashcardRepository.Add(flashcard);

			await Task.CompletedTask;
		}

		public async Task Delete(Guid id)
		{
			_localFlashcardRepository.RemoveAll(temp => temp.Id == id);

			await Task.CompletedTask;
		}

		public async Task<IEnumerable<Flashcard>?> GetAllCards()
		{
			return await Task.FromResult(_localFlashcardRepository);
		}

		public async Task<Flashcard?> GetById(Guid id)
		{
			return await Task.FromResult(_localFlashcardRepository.FirstOrDefault(temp => temp.Id == id));
		}

		public async Task<IEnumerable<Flashcard>?> GetCardsToReview()
		{
			return await Task.FromResult( _localFlashcardRepository.Where(temp => temp.NextRepeatDate <= DateTime.Now.ToDateOnly()));
		}

		public async Task ReviewCard(Guid cardId, int responseQuality)
		{
			var card = await GetById(cardId);

			card.RepetitionCount++;

			UpdateInterRepetitionInterval(card);
			UpdateEFactor(card, responseQuality);

			if (responseQuality < 3)
			{
				card.RepetitionCount = 0;
				card.NextRepeatDate = DateTime.Now.ToDateOnly();
			}
		}

		public async Task Update(Guid id, string mainSide, string oppositeSide)
		{
			var card = await GetById(id);

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
