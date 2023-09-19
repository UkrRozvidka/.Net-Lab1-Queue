using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Runner
    {
        private Dictionary<CommandEnum, ICommand> commandDictionary;

        public Runner(Queue<int> queue)
        {
            commandDictionary = new Dictionary<CommandEnum, ICommand>()
            {
                { CommandEnum.Enqueue, new EnqueueInt(queue)},
                { CommandEnum.Dequeue, new Dequeue<int>(queue)},
                { CommandEnum.Contains, new ContainsInt(queue)},
                { CommandEnum.Clear, new Clear<int>(queue)},
                { CommandEnum.Peek, new Peek<int>(queue)},
                { CommandEnum.TryPeek, new TryPeek<int>(queue)},
                { CommandEnum.TryDequeue, new TryDequeue<int>(queue)},
                { CommandEnum.ShowAll, new ShowAll<int>(queue)}
            };
        }
        public void Run()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Додати елемент до колекції");
                Console.WriteLine("2. Видалити елемент з колекції");
                Console.WriteLine("3. Перевірити наявність елемента в колекції");
                Console.WriteLine("4. Очистити колекцію");
                Console.WriteLine("5. Дізнатися перший елемент колекції (Peek)");
                Console.WriteLine("6. Спроба дізнатися перший елемент колекції (TryPeek)");
                Console.WriteLine("7. Спроба видалити перший елемент колекції (TreDequeue)");
                Console.WriteLine("8. Вивести всі елементи колекції");
                Console.WriteLine("9. Вихід з програми");
                Console.ForegroundColor= ConsoleColor.White;

                int.TryParse(Console.ReadLine(), out int choice);
                var commandInvoker = new CommandInvoker();

                if (commandDictionary.TryGetValue((CommandEnum)choice, out ICommand selectedCommand))
                {
                    commandInvoker.SetCommand(selectedCommand);
                    try
                    {
                        commandInvoker.ExecuteCommand();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Очередь пуста.");
                    }
                }
                else if (choice == 9)
                {
                    Console.WriteLine("Вихід!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Невірна команда!!!");
                }
            }
        }
    }
}
