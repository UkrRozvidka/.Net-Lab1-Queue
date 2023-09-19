using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Queue
{
    public class EnqueueInt : ICommand
    {
        private readonly Queue<int> queue;

        public EnqueueInt(Queue<int> queue)
        {
            this.queue = queue;
        }

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            Console.Write("Введіть значення яке хочете додати: ");
             
            if(int.TryParse(Console.ReadLine(), out int item))
            {
                queue.Enqueue(item);
                Console.WriteLine(item.ToString() + " було додано до колекції");
            }
            else
            {
                Console.WriteLine("Було введено невалідне значення");
            }          
        }
    }

    public class Dequeue<T> : ICommand
    {
        private readonly Queue<T> queue;

        public Dequeue(Queue<T> queue) => this.queue = queue;

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            Console.WriteLine(queue.Dequeue().ToString() + " було видалено з колекції");
        }
    }

    public class ContainsInt : ICommand
    {
        private readonly Queue<int> queue;


        public ContainsInt(Queue<int> queue)
        {
            this.queue = queue;
        }

        public void Execute()
        {

            if (queue == null) throw new ArgumentNullException(nameof(queue));
            Console.Write("Введіть значення яке хочете знайти: ");

            if (!int.TryParse(Console.ReadLine(), out int item))
                Console.WriteLine("Було введено невалідне значення");

            if (queue.Contains(item))
                Console.WriteLine(item.ToString() + " знайдено в колекції");
            else
                Console.WriteLine(item.ToString() + " відсутній в колекції");
        }
    }

    public class Clear<T> : ICommand
    {
        private readonly Queue<T> queue; 

        public Clear(Queue<T> queue) => this.queue = queue;

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            queue.Clear();
            Console.WriteLine("Колекція очищена");
        }
    }

    public class Peek<T> : ICommand
    {
        private readonly Queue<T> queue;

        public Peek(Queue<T> queue) => this.queue = queue;

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            Console.WriteLine(queue.Peek().ToString() + " перший елемент в колекції");
        }
    }
    public class TryPeek<T> : ICommand
    {
        private readonly Queue<T> queue;

        public TryPeek(Queue<T> queue) => this.queue = queue;

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            if(queue.TryPeek(out T res))
            {
                Console.WriteLine(res.ToString() + " перший елемент в колекції");
            }
            else
            {
                Console.WriteLine("Колекція пуста");
            }
        }
    }

    public class TryDequeue<T> : ICommand
    {
        private readonly Queue<T> queue;

        public TryDequeue(Queue<T> queue) => this.queue = queue;

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            if (queue.TryDequeue(out T res))
            {
                Console.WriteLine(res.ToString() + " було видалено");
            }
            else
            {
                Console.WriteLine("Колекція пуста");
            }
        }
    }

    public class ShowAll<T> : ICommand
    {
        private readonly Queue<T> queue;

        public ShowAll(Queue<T> queue) => this.queue = queue;

        public void Execute()
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            foreach (T item in queue)
                Console.Write($"{item}; ");
            Console.WriteLine();    
        }
    }
}
