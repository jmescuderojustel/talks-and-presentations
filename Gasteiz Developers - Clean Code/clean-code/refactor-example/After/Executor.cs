using After.Config;
using After.Entities;
using System;
using System.IO;
using System.Linq;

namespace After
{
    public class Executor
    {
        private readonly ExecutorLogger _logger;

        private EmailAccountUseSummary _summary = new EmailAccountUseSummary();

        public Executor(ExecutorLogger logger)
        {
            _logger = logger;
        }

        public void CalculateEmailAccountUse()
        {
            _logger.Init();

            FileStream userListFile = new FileStream(Configuration.UserListFilePath, FileMode.Open);

            using (StreamReader userListFileReader = new StreamReader(userListFile))
            {
                ProcessUserListReader(userListFileReader);
            }

            _summary.UpdateSummaryWithMostUsedEmail();
        }

        public void LogSummary()
        {
            _logger.Summary(_summary);
        }

        private void ProcessUserListReader(StreamReader userListFileReader)
        {
            _logger.StartProcess();

            bool isCurrentLineTheHeader = true;

            while (!userListFileReader.EndOfStream)
            {
                string line = userListFileReader.ReadLine();

                if (isCurrentLineTheHeader)
                {
                    isCurrentLineTheHeader = false;
                    continue;
                }

                ProcessUserListFileLine(line);
            }

            _logger.FinishProcess();
        }

        private void ProcessUserListFileLine(string line)
        {
            string[] items = line.Split(new string[] { Configuration.ColumnSeparator }, StringSplitOptions.None);

            string userEmailAddress = items[Configuration.EmailColumnIndex];

            Email userEmail = new Email(userEmailAddress);

            ProcessUserEmail(userEmail);

            _logger.NewItemProcessed();
        }

        private void ProcessUserEmail(Email userEmail)
        {
            string emailServerAddress = userEmail.ServerAddress;
            bool shouldTrackThisEmail = Configuration.TracedEmailAccounts.Contains(emailServerAddress);

            if (shouldTrackThisEmail)
            {
                _summary.TrackedEmailsUsed.Append(emailServerAddress);
            }
            else
            {
                _summary.UntrackedEmailsUsed.Append(emailServerAddress);
            }
        }
    }
}