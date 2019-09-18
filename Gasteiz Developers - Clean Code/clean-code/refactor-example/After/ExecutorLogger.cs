using After.Entities;
using After.Extensions;
using After.Logger;

namespace After
{
    public class ExecutorLogger
    {
        private int _count;

        private readonly ILogger _log;

        public ExecutorLogger(ILogger log)
        {
            _log = log;
        }

        internal void Summary(EmailAccountUseSummary summary)
        {
            _log.NewLine();

            foreach (var emailAccount in summary.TrackedEmailsUsed)
            {
                _log.WriteLine($"{ emailAccount.EmailServer.Capitalize() }: { emailAccount.Count }");
            }

            _log.WriteLine($"Most used not tracked email: { summary.MostUsedNotTrackedEmailAccount.EmailServer }");
        }

        internal void Init()
        {
            _count = 0;
        }

        internal void StartProcess()
        {
            _log.WriteLine("\nSTARTED\n");
        }

        internal void FinishProcess()
        {
            _log.WriteLine("\nFINISHED\n");
        }

        internal void NewItemProcessed()
        {
            _count++;
            _log.Write($"{ _count }, ");
        }
    }
}