namespace CommonNews.Web.Helpers
{
    public static class StringExtensions
    {
        public static string Limit(this string input, int max)
        {
            if (!string.IsNullOrEmpty(input) && input.Length > max)
            {
                return input.Substring(0, max) + "...";
            }

            return input;
        }
    }
}
