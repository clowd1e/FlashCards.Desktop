using FlashCards.Desktop.Helpers;
using FlashCards.Desktop.Models;
using FlashCards.Desktop.Repositories;
using FlashCards.Desktop.RepositoryContracts;
using FlashCards.Desktop.ServiceContracts;
using Newtonsoft.Json;

namespace FlashCards.Desktop.Services
{
	public class CardService : ICardService
	{
		private readonly ILocalCardRepository _localCardRepository;
		private readonly ApiRepository _apiRepository;
		private readonly int _maxResponseQuality;

        public CardService(ILocalCardRepository localCardRepository, ApiRepository apiRepository, int maxResponseQuality = 5)
        {
            _localCardRepository = localCardRepository;
			_apiRepository = apiRepository;
			_maxResponseQuality = maxResponseQuality;
        }

        public async Task CreateCard(Flashcard? flashcard)
		{
			await ValidationHelper.ValidateObjects(flashcard);

			await _localCardRepository.CreateCard(flashcard!);
		}

		public async Task DeleteCard(Guid? id)
		{
			await ValidationHelper.ValidateObjects(id);

			await _localCardRepository.DeleteCard(id!.Value);
		}

		public async Task<IEnumerable<Flashcard>> GetAllCards()
		{
			var cards = await _localCardRepository.GetAllCards();

			if (cards is null)
			{
				throw new NullReferenceException("Unable to get all cards.");
			}

			return cards;
		}

		public async Task<Flashcard> GetCardById(Guid? id)
		{
			await ValidationHelper.ValidateObjects(id);

			var card = await _localCardRepository.GetCardById(id!.Value);

			if (card is null)
			{
				throw new ArgumentException("Unable to get card by id. Most likely, the id is invalid.");
			}

			return card;
		}

		public async Task<IEnumerable<Flashcard>> GetCardsToReview()
		{
			var cards = await _localCardRepository.GetCardsToReview();

			if (cards is null)
			{
				throw new NullReferenceException("Unable to get cards to review.");
			}

			return cards;
		}

		public async Task ReviewCard(Guid? cardId, int? responseQuality)
		{
			await ValidationHelper.ValidateObjects(cardId, responseQuality);

			if (responseQuality > _maxResponseQuality || responseQuality < 0)
			{
				throw new ArgumentOutOfRangeException($"Unable to review the card. Response quality cannot be less than 0 and more than {_maxResponseQuality}");
			}

			await _localCardRepository.ReviewCard(cardId!.Value, responseQuality!.Value);
		}

		public async Task SyncWithRemoteStorage(List<Flashcard>? flashcards)
		{
			await ValidationHelper.ValidateObjects(flashcards);

			var remoteCards = await _apiRepository.GetAllCards();

			if (remoteCards is null)
			{
				throw new JsonSerializationException("Failed to deserialize cards.");
			}

			var localCards = await GetAllCards();

			var result = remoteCards.Union(localCards).ToList();

			if (result is null)
			{
				throw new Exception("Failed to union the cards.");
			}

			await _localCardRepository.ResetRepository(result);
		}

		public async Task UpdateCard(Guid? id, string? mainSide, string? oppositeSide)
		{
			await ValidationHelper.ValidateObjects(id, mainSide, oppositeSide);

			if (string.IsNullOrEmpty(mainSide) ||
				string.IsNullOrEmpty(oppositeSide))
			{
				throw new ArgumentException("The card's content cannot be empty");
			}

			await _localCardRepository.UpdateCard(id!.Value, mainSide, oppositeSide);
		}
	}
}
