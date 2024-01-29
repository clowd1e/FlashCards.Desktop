using FlashCards.Desktop.Models;

namespace FlashCards.Desktop.RepositoryContracts
{
	public interface ILocalCardRepository
	{
		Task ReviewCard(Guid cardId, int responseQuality);

		Task<IEnumerable<Flashcard>?> GetCardsToReview();

		Task<IEnumerable<Flashcard>?> GetAllCards();

		Task Update(Guid id, string mainSide, string oppositeSide);
	}
}
