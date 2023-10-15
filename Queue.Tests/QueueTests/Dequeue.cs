using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Dequeue
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Deque_WhenQueueNotEmpty_ShoudRemoveAndReturnFirstElement<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            int count = objects.Length;

            foreach (var item in objects)
            {
                Assert.Equal(item, queue.Dequeue());
                Assert.Equal(--count, queue.Count);
            }
            Assert.Empty(queue);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void Deque_WhenQueueIsEmpty_ShoudThrowInvalidOperationExeption<T>(Queue<T> queue)
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}
