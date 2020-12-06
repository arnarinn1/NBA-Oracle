namespace ValueObjects.Extensions
{
    public static class ObjectValidationExtensions
    {
        public static object DiscardNullOrWhitespaceCheck(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? value : null;
        }
    }
}