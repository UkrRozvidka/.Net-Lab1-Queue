using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Enqueue
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Enqueue_ShoudAddElement<T>(T[] objects)
        {
            var queue = new Queue<T>();

            foreach (var item in objects)
                queue.Enqueue(item);

            Assert.Equal(objects.Length, queue.Count);
            Assert.Equal(queue, objects);
        }
    }
}
