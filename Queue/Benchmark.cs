using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Queue
{


    // присутнє дублювання коду через проблеми на моїй машині запускати конструктор класу BenchmarkDotNet
    public class ArrayQueueVsLinkedListQueueEnqueueInt
    {
        //results https://cdn.discordapp.com/attachments/676701120344621056/1153803755146465391/image.png
        public Queue.Queue<int> LinkedListQueue { get; set; }
        public System.Collections.Generic.Queue<int> ArrayQueue { get; set; }

        [Params(32, 1024, 8194)]
        public int count;

        Random rnd = new Random(17);

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<int>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(rnd.Next());
            }
        }

        [Benchmark]
        public void EnqueueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<int>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(rnd.Next());
            }
        }
    }

    public class ArrayQueueVsLinkedListQueueEnqueueLazy
    {

        //res https://cdn.discordapp.com/attachments/676701120344621056/1153805439935459409/image.png
        public Queue.Queue<Lazy<int>> LinkedListQueue { get; set; }
        public System.Collections.Generic.Queue<Lazy<int>> ArrayQueue { get; set; }

        [Params(32, 1024, 8194)]
        public int count;

        Random rnd = new Random(17);

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<Lazy<int>>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(new Lazy<int>(rnd.Next()));
            }
        }

        [Benchmark]
        public void EnqueueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(new Lazy<int>(rnd.Next()));
            }
        }
    }


    public class LargeObject
    {
        public string str1;
        public string str2;
        public Lazy<string> str3;
        public Lazy<string> str4;
    }

    public class ArrayQueueVsLinkedListQueueEnqueueLargeObject
    {
        // res https://cdn.discordapp.com/attachments/676701120344621056/1153808633537249340/image.png
        public Queue.Queue<LargeObject> LinkedListQueue { get; set; }
        public System.Collections.Generic.Queue<LargeObject> ArrayQueue { get; set; }

        [Params(32, 1024, 8194)]
        public int count;

        Random rnd = new Random(17);

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<LargeObject>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue( new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500))),
                });
            }
        }

        [Benchmark]
        public void EnqueueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<LargeObject>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500))),
                });
            }
        }
    }

    [MemoryDiagnoser]
    public class ArrayQueueVsLinkedListQueueFullInt
    {
        // res https://cdn.discordapp.com/attachments/676701120344621056/1153812241683071027/image.png
        public Queue.Queue<int> LinkedListQueue {  get; set; }
        public System.Collections.Generic.Queue<int> ArrayQueue {  get; set; }

        [Params(32, 1024, 8194)]
        public int count;

        Random rnd = new Random(17);
          
        #region enqueue

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<int>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(rnd.Next());
            }    
        }

        [Benchmark]
        public void EnqueueArrayQueue() 
         {
            ArrayQueue = new System.Collections.Generic.Queue<int>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(rnd.Next());
            }
        }

        #endregion

        #region dequeue

        [Benchmark]
        public void DequeueLinkedListQueue()
        {
            LinkedListQueue = new Queue.Queue<int>(Enumerable.Range(0, count)
                .Select(x => rnd.Next()));
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Dequeue();
            }
        }

        [Benchmark]
        public void DequeueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<int>(Enumerable.Range(0, count)
                .Select(x => rnd.Next()));
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Dequeue();
            }
        }

        #endregion

        #region foreach

        [Benchmark]
        public void ForeachLinkedListQueue()
        {
            long sum = 0;
            LinkedListQueue = new Queue.Queue<int>(Enumerable.Range(0, count)
                .Select(x => rnd.Next()));
            foreach (var t in LinkedListQueue)
            {
                sum += t;
            }
        }

        [Benchmark]
        public void ForeachArrayQueue()
        {
            long sum = 0;
            ArrayQueue = new System.Collections.Generic.Queue<int>(Enumerable.Range(0, count)
                .Select(x => rnd.Next()));
            foreach (var t in ArrayQueue)
            {
                sum += t;
            }
        }
        #endregion
    }

    [MemoryDiagnoser]
    public class ArrayQueueVsLinkedListQueueFullLazy
    {
        // res https://cdn.discordapp.com/attachments/676701120344621056/1153814718625103953/image.png
        public Queue.Queue<Lazy<int>> LinkedListQueue { get; set; }
        public System.Collections.Generic.Queue<Lazy<int>> ArrayQueue { get; set; }

        [Params(32, 1024, 8194)]
        public int count;

        Random rnd = new Random(17);

        #region enqueue

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<Lazy<int>>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(new Lazy<int>(rnd.Next()));
            }
        }

        [Benchmark]
        public void EnqueueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(new Lazy<int>(rnd.Next()));
            }
        }

        #endregion

        #region dequeue

        [Benchmark]
        public void DequeueLinkedListQueue()
        {
            LinkedListQueue = new Queue.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(rnd.Next())));
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Dequeue();
            }
        }

        [Benchmark]
        public void DequeueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(rnd.Next())));
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Dequeue();
            }
        }

        #endregion

        #region foreach

        [Benchmark]
        public void ForeachLinkedListQueue()
        {
            long sum = 0;
            LinkedListQueue = new Queue.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(rnd.Next())));
            foreach (var t in LinkedListQueue)
            {
                sum += t.Value;
            }
        }

        [Benchmark]
        public void ForeachArrayQueue()
        {
            long sum = 0;
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(rnd.Next())));
            foreach (var t in ArrayQueue)
            {
                sum += t.Value;
            }
        }
        #endregion
    }

    [MemoryDiagnoser]
    public class ArrayQueueVsLinkedListQueueFullLargeObject
    {
        // res https://cdn.discordapp.com/attachments/676701120344621056/1153817380926005318/image.png
        public Queue.Queue<LargeObject> LinkedListQueue { get; set; }
        public System.Collections.Generic.Queue<LargeObject> ArrayQueue { get; set; }

        [Params(32, 1024, 8194)]
        public int count;

        Random rnd = new Random(17);

        #region enqueue

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<LargeObject>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500)))
                });
            }
        }

        [Benchmark]
        public void EnqueueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<LargeObject>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500)))
                });
            }
        }

        #endregion

        #region dequeue

        [Benchmark]
        public void DequeueLinkedListQueue()
        {
            LinkedListQueue = new Queue.Queue<LargeObject>(Enumerable.Range(0, count)
                .Select(x => new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500)))
                }));
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Dequeue();
            }
        }

        [Benchmark]
        public void DequeueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<LargeObject>(Enumerable.Range(0, count)
                .Select(x => new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500)))
                }));
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Dequeue();
            }
        }

        #endregion

        #region foreach

        [Benchmark]
        public void ForeachLinkedListQueue()
        {
            int sum = 0;
            LinkedListQueue = new Queue.Queue<LargeObject>(Enumerable.Range(0, count)
                .Select(x => new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500)))
                }));
            foreach (var t in LinkedListQueue)
            {
                sum += t.str1.Length + t.str2.Length + t.str3.Value.Length + t.str4.Value.Length;
            }
        }

        [Benchmark]
        public void ForeachArrayQueue()
        {
            long sum = 0;
            ArrayQueue = new System.Collections.Generic.Queue<LargeObject>(Enumerable.Range(0, count)
                .Select(x => new LargeObject
                {
                    str1 = new string('p', 300),
                    str2 = new string('c', 500),
                    str3 = new Lazy<string>(new string('y', rnd.Next(100, 500))),
                    str4 = new Lazy<string>(new string('u', rnd.Next(100, 500)))
                }));
            foreach (var t in ArrayQueue)
            {
                sum += t.str1.Length + t.str2.Length + t.str3.Value.Length + t.str4.Value.Length;
            }
        }
        #endregion
    }
}
