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

    [MemoryDiagnoser]
    public class ArrayQueueVsLinkedListQueue
    {
        public Queue.Queue<Lazy<int>> LinkedListQueue {  get; set; }
        public System.Collections.Generic.Queue<Lazy<int>> ArrayQueue {  get; set; }

        [Params(32, 1024, 8194)]
        public int count;
          
        #region enqueue

        //[Benchmark]
        public void EnqueueLinkedListQueue()
        {
            LinkedListQueue = new Queue<Lazy<int>>();
            for (int i = 0; i < count; i++)
            {
                LinkedListQueue.Enqueue(new Lazy<int>(int.MaxValue));
            }    
        }

        //[Benchmark]
        public void EnqueueArrayQueue() 
         {
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>();
            for (int i = 0; i < count; i++)
            {
                ArrayQueue.Enqueue(new Lazy<int>(int.MaxValue));
            }
        }

        #endregion

        #region dequeue

        //[Benchmark]
        public void DequeueLinkedListQueue()
        {
            LinkedListQueue = new Queue.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(int.MaxValue)));
            for (int i = 0; i < count; i++)
            {
                 LinkedListQueue.Dequeue();
            }
        }

        //[Benchmark]
        public void DequeueArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(int.MaxValue)));
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
            LinkedListQueue = new Queue.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(int.MaxValue)));
            foreach(var t in LinkedListQueue)
            {

            }
        }

        [Benchmark]
        public void ForeachArrayQueue()
        {
            ArrayQueue = new System.Collections.Generic.Queue<Lazy<int>>(Enumerable.Range(0, count)
                .Select(x => new Lazy<int>(int.MaxValue)));
            foreach(var t in  ArrayQueue)
            {

            }
        }

        #endregion
    }
}
