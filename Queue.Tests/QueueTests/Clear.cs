using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Clear
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Clear_ShoudRemoveAllElements<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            queue.Clear();

            Assert.Empty(queue);
            Assert.Equal(0, queue.Count);
        }
    }
}
