using Xunit;

namespace Queue.Tests.QueueTests
{
    public class Enumerator
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetEnumerator_ShouldReturnElementInCorrectOrder<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            var enumerator = queue.GetEnumerator();

            for (int i = 0; i < objects.Length; i++)
            {
                enumerator.MoveNext();
                Assert.Equal(enumerator.Current, objects[i]);
            }
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void GetEnumerator_WhenQueueEmpty_MoveNextShouldReturnFalse<T>(Queue<T> queue)
        {
            var enumerator = queue.GetEnumerator();
            Assert.False(enumerator.MoveNext());
        }
    }
}
