using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks;

namespace Queue
{

    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser]
    public class ArrayQueueVsLinkedListQueue
    {
        public Queue.Queue<int> LinkedListQueue {  get; set; }
        public System.Collections.Generic.Queue<int> ArrayQueue {  get; set; }

        private readonly Random random = new Random(Seed : 17);

        [Params(1, 16, 512)]
        public int count;

        [Benchmark]
        public void EnqueueLinkedListQueue()
        {
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(i);
            }    
        }

        [Benchmark]
         public void EnqueueArrayQueue() 
         {
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(i);
            }
        }
    }
}
