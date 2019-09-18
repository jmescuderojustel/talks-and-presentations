using After.Logger;

namespace After
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleLogger = new ConsoleLogger();
            var executorLogger = new ExecutorLogger(consoleLogger);
            var after = new Executor(executorLogger);

            after.CalculateEmailAccountUse();
            after.LogSummary();
        }
    }
}