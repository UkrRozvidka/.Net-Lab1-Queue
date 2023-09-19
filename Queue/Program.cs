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
        //BenchmarkRunner.Run<ArrayQueueVsLinkedListQueue>(); //uncoment to run benchmark
        Console.OutputEncoding = Encoding.Unicode;
        var q = new Queue.Queue<int>();
        var eventListener = new EventListener<int>();
        q.OnAddElement += eventListener.OnAdd;
        q.OnRemoveElement += eventListener.OnDelete;
        var runner = new Runner(q);
        runner.Run();
    }
}