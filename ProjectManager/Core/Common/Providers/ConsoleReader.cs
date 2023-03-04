using ProjectManager.Core.Common.Contracts;

namespace ProjectManager.Core.Common.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
