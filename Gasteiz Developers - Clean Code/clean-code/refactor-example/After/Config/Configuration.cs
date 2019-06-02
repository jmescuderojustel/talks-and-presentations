namespace After.Config
{
    public static class Configuration
    {
        public static string UserListFilePath => @"Data\UK email list.csv";
        public static string ColumnSeparator => "\",\"";
        public static string[] TracedEmailAccounts => new[] { "yahoo.com", "gmail.com" };
        public static int EmailColumnIndex => 9;
    }
}