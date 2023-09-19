using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    enum CommandEnum
    {
        Enqueue = 1,
        Dequeue,
        Contains,
        Clear,
        Peek,
        TryPeek,
        TryDequeue,
        ShowAll
    }
}
