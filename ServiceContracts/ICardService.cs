using FlashCards.Desktop.Models;

namespace FlashCards.Desktop.ServiceContracts
{
	public interface ICardService
	{
		Task ReviewCard(Guid cardId, int responseQuality);

		Task UpdateCard(Guid id, string mainSide, string oppositeSide);

		Task CreateCard(Flashcard flashcard);

		Task DeleteCard(Guid id);

		Task<IEnumerable<Flashcard>?> GetCardsToReview();

		Task<IEnumerable<Flashcard>?> GetAllCards();

		Task<Flashcard> GetCardById(Guid id);
	}
}
