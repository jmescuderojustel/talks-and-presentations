namespace After.Entities
{
    public class EmailAccountUse
    {
        public string EmailServer { get; private set; }
        public int Count { get; private set; }

        public EmailAccountUse()
        {
        }

        public EmailAccountUse(string email)
        {
            EmailServer = email;
            Count = 1;
        }

        internal void Add()
        {
            Count += 1;
        }
    }
}