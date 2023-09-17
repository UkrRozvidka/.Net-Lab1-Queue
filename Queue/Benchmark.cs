﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks;

namespace Queue
{

    [MemoryDiagnoser]
    public class ArrayQueueVsLinkedListQueue
    {
        public ArrayQueueVsLinkedListQueue()
        {
            LinkedListQueue = new Queue<int>();
            ArrayQueue = new System.Collections.Generic.Queue<int>();
        }

        public Queue.Queue<int> LinkedListQueue {  get; set; }
        public System.Collections.Generic.Queue<int> ArrayQueue {  get; set; }

        private readonly Random random = new Random(Seed : 17);


        [Params (10, 256, 1024)]
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