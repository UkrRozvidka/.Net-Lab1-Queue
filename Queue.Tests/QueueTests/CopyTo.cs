using Xunit;

namespace Queue.Tests.QueueTests
{
    public class CopyTo
    {
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CopyTo_ShouldCopiesElements<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            var array = new T[objects.Length];

            queue.CopyTo(array, 0);

            Assert.Equal(objects, array);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CopyTo_ShouldStartsAtCorrectIndex<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            var array = new T[objects.Length + 2];

            queue.CopyTo(array, 1);

            Assert.Equal(default, array[0]);
            Assert.Equal(objects, array[1..(array.Length - 1)]);
            Assert.Equal(default, array[array.Length - 1]);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void CopyTo_WhenIndexOutOfArrayRange_ShouldThrowIndexOutOfRangeException<T>(Queue<T> queue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => queue.CopyTo(new int[5], -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => queue.CopyTo(new int[5], 5));
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CopyTo_WhenDestinationArrayHasNotEnoughSpace_ShouldThrowArgumentException<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            Assert.Throws<ArgumentException>(() => queue.CopyTo(new T[objects.Length - 2], 0));
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void CopyTo_WhenArrayMultidimensional_ShouldThrowArgumentException<T>(Queue<T> queue)
        {
            Assert.Throws<ArgumentException>(() => queue.CopyTo(new int[2, 2], 0));
        }
    }
}
