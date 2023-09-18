using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Queue
{
    public class EnqueueCommand<T> : ICommand
    {
        private readonly Queue<T> queue;
        private readonly T item;

        public EnqueueCommand(Queue<T> queue, T item)
        {
            this.queue = queue;
            this.item = item;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть значення яке хочете додати: ");
            var t = Console.ReadLine();
            
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            queue.Enqueue(item);
            Console.WriteLine(item.ToString() + " було додано до колекції");
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

    public class Contains<T> : ICommand
    {
        private readonly Queue<T> queue;
        private readonly T item;

        public Contains(Queue<T> queue, T item)
        {
            this.queue = queue;
            this.item = item;
        }

        public void Execute()
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (queue == null) throw new ArgumentNullException(nameof(queue));
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
}
