namespace AsyncLogger
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await Task.WhenAll(Starter.Run(), Starter.Run());
        }
    }
}