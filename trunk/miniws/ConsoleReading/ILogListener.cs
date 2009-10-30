namespace miniws
{
    internal interface ILogListener
    {
        // ReSharper disable InconsistentNaming
        void writeChars(char[] buffer, int i, int read);
        // ReSharper restore InconsistentNaming
    }
}