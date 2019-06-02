namespace After.Entities
{
    public class EmailAccountUseSummary
    {
        public EmailAccountUseList TrackedEmailsUsed;
        public EmailAccountUseList UntrackedEmailsUsed;

        public EmailAccountUse MostUsedNotTrackedEmailAccount;

        public EmailAccountUseSummary()
        {
            TrackedEmailsUsed = new EmailAccountUseList();
            UntrackedEmailsUsed = new EmailAccountUseList();

            MostUsedNotTrackedEmailAccount = new EmailAccountUse();
        }

        internal void UpdateSummaryWithMostUsedEmail()
        {
            foreach (var emailAccountUse in UntrackedEmailsUsed)
            {
                if (emailAccountUse.Count <= MostUsedNotTrackedEmailAccount.Count)
                {
                    continue;
                }

                MostUsedNotTrackedEmailAccount = emailAccountUse;
            }
        }
    }
}