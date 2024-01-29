using FlashCards.Desktop.Extensions;

namespace FlashCards.Desktop.Models
{
	public class Flashcard : IEntity
	{
		public Guid Id { get; set; }

		public float EFactor { get; set; }

		public int RepetitionCount { get; set; }

		public DateOnly NextRepeatDate { get; set; } = DateTime.Now.ToDateOnly();

		public string? MainSide { get; set; }

		public string? OppositeSide { get; set; }
	}
}
