using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Contains
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Contains_WhenElementExist_ShoudReturnTrue<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            foreach (var item in objects)
                Assert.True(queue.Contains(item));
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Contains_WhenElementExist_ShoudReturnFalse<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                Assert.False(queue.Contains(element));
            }
        }
    }
}
