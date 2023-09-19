using Microsoft.Diagnostics.Tracing.Parsers.JScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class EventListener<T>
    {
        public void OnAdd (object sender, QueueEventArgs<T> e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Was added item {e.Item}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void OnDelete(object sender, QueueEventArgs<T> e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Was deleted item {e.Item}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
