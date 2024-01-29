namespace FlashCards.Desktop.Extensions
{
	public static class DateTimeExtensions
	{
		public static DateOnly ToDateOnly(this DateTime date)
		{
			return DateOnly.FromDateTime(date);
		}
	}
}
