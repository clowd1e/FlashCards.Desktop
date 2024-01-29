namespace FlashCards.Desktop.Models
{
	public class Flashcard : IEntity
	{
		public Guid Id { get; set; }

		public float EFactor { get; set; }

		public int RepetitionCount { get; set; }

		public int RepeatInDays { get; set; }

		public string? MainSide { get; set; }

		public string? OppositeSide { get; set; }
	}
}
