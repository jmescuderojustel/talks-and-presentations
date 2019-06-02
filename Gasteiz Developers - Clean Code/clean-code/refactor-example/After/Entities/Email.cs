namespace After.Entities
{
    internal class Email
    {
        public string Account { get; private set; }

        public string ServerAddress
        {
            get
            {
                int afterAtPosition = Account.IndexOf("@") + 1;
                int serverAddressLength = Account.Length - afterAtPosition;

                string serverAddress = Account.Substring(afterAtPosition, serverAddressLength);

                return serverAddress;
            }
        }

        public Email(string account)
        {
            Account = account;
        }
    }
}