
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased.GitHubOutputBased
{

    public interface ILogger
    {
        void Log(string message);
        void LogError(string message) => Log($"Error: {message}");
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    internal class _6File
    {
        public static void Main()
        {
            ILogger logger = new ConsoleLogger();
            logger.LogError("An error occurred.");
        }
    }
}
