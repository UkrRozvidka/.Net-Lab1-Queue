using Xunit;

namespace Queue.Tests.QueueTests
{
    public class TryDequeue
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void TryDequeue_WhenQueueNotEmpty_ShouldReturnTrueAndPutValueInParameterVariableWithRemoving<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            var res = queue.TryDequeue(out T value);

            Assert.True(res);
            Assert.Equal(value, objects[0]);
            Assert.Equal(queue.Count, objects.Length - 1);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void TryDequeue_WhenQueueEmpty_ShouldReturnFalseAndPutDefaultValueInParameterVariable<T>(Queue<T> queue)
        {
            var res = queue.TryDequeue(out T value);

            Assert.False(res);
            Assert.Equal(value, default);
            Assert.Empty(queue);
        }
    }
}
