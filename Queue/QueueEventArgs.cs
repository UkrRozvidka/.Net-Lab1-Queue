using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueEventArgs<T> : EventArgs
    {
        public T Item { get; private set; }
        public string Message { get; private set; }

        public QueueEventArgs(T item, string message = "") 
        {
            Item = item;
            Message = message;
        }
    }
}
