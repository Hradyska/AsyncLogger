namespace AsyncLogger
{
    internal sealed class BusinessException : Exception
    {
        public BusinessException(DateTime time, string message)
        {
            ExMessage = message;
            ErrorTime = time;
        }

        public string ExMessage { get; set; }

        public DateTime ErrorTime { get; set; }
    }
}
