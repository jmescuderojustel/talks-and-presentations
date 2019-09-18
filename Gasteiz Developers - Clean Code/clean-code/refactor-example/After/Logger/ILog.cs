namespace After.Logger
{
    public interface ILogger
    {
        void Write(string text);

        void WriteLine(string text);

        void NewLine();
    }
}