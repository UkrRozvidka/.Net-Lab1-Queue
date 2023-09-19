using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Queue;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args)
    {
        // UNCOMMENT CONCRETE BENCHMARK TO RUN IT
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueueEnqueueInt>();
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueueEnqueueLazy>();
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueueEnqueueLargeObject>();
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueueFullInt>();
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueueFullLazy>();
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueueFullLargeObject>();

    }
}