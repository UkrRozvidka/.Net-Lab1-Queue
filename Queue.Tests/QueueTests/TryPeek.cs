using Xunit;

namespace Queue.Tests.QueueTests
{
    public class TryPeek
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void TryPeek_WhenQueueNotEmpty_ShoudReturnTrueAndPutValueInParametrVariableWithoutRemoving<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            var res = queue.TryPeek(out T value);

            Assert.True(res);
            Assert.Equal(value, objects[0]);
            Assert.Equal(queue, objects);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void TryPeek_WhenQueuуEmpty_ShoudReturnFalseAndPutDefaultValueInParametrVariable<T>(Queue<T> queue)
        {
            var res = queue.TryPeek(out T value);

            Assert.False(res);
            Assert.Equal(value, default);
            Assert.Empty(queue);
        }
    }
}
