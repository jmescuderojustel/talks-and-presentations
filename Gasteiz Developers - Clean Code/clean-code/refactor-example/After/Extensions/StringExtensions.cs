namespace After.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            string firstLetter = text.Substring(0, 1);
            string restOfText = text.Substring(1, text.Length - 1);

            string capitalizedText = firstLetter.ToUpper() + restOfText;

            return capitalizedText;
        }
    }
}