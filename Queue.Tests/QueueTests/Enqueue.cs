using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Enqueue
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Enqueue_ShouldAddElement<T>(T[] objects)
        {
            var queue = new Queue<T>();
            foreach (var item in objects)
            {
                queue.Enqueue(item);
            }

            var eventTriggered = false;
            queue.OnAddElement += (sender, e) =>
            {
                eventTriggered = true;
                Assert.Contains(e.Item, objects);
                Assert.True(eventTriggered);
            };

            Assert.Equal(objects.Length, queue.Count);
            Assert.Equal(queue, objects);
        }
        
        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void Enqueue_WhenItemNull_ShouldThrowArgumentNullException<T>(Queue<T?> queue)
        {
            var item = default(T);
            if(item is not ValueType)
                Assert.Throws<ArgumentNullException>(() => queue.Enqueue(item));
        }
    }
}
