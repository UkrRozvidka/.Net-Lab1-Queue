using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Peek
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Peek_WhenQueueNotEmpty_ShoudReturnFirstElementWithoutRemoving<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            var item = queue.Peek();

            Assert.Equal(item, objects[0]);
            Assert.Equal(queue, objects);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void Peek_WhenQueueEmpty_ShoudThrowInvalidOperationException<T>(Queue<T> queue)
        {
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
