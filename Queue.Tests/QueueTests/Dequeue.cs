using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Dequeue
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Deque_WhenQueueNotEmpty_ShouldRemoveAndReturnFirstElement<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            int count = objects.Length;

            foreach (var item in objects)
            {
                Assert.Equal(item, queue.Dequeue());
                Assert.Equal(--count, queue.Count);
                var eventTriggered = false;
                queue.OnRemoveElement += (sender, e) =>
                {
                    eventTriggered = true;
                    Assert.Contains(e.Item, objects);
                    Assert.True(eventTriggered);
                };
            }
            Assert.Empty(queue);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void Deque_WhenQueueIsEmpty_ShouldThrowInvalidOperationException<T>(Queue<T> queue)
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}
