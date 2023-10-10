using Xunit;
using Queue;
using System.Collections.Generic;
using Xunit.Sdk;
using System.Collections;

namespace Queue.Tests
{
    public class QueueTest
    {

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Enqueue_ShoudAddElement<T>(T[] objects)
        {
            var queue = new Queue<T>();

            foreach (var item in objects)
                queue.Enqueue(item);

            Assert.Equal(objects.Length, queue.Count);
            Assert.Equal(queue, objects);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Deque_WhenQueueNotEmpty_ShoudRemoveAndReturnFirstElement<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            int count = objects.Length;

            foreach(var item in objects)
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
            Assert.Throws<InvalidOperationException>( () => queue.Dequeue());
        }


        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Clear_ShoudRemoveAllElements<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            queue.Clear();

            Assert.Empty(queue);
            Assert.Equal(0, queue.Count);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Contains_WhenElementExist_ShoudReturnTrue<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            foreach(var item in objects)
                Assert.True(queue.Contains(item));
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void Contains_WhenElementExist_ShoudReturnFalse<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            while(queue.Count > 0)
            {
                var element = queue.Dequeue();
                Assert.False(queue.Contains(element));
            }
        }

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
        public void TryPeek_WhenQueuóEmpty_ShoudReturnFalseAndPutDefaultValueInParametrVariable<T>(Queue<T> queue)
        {
            var res = queue.TryPeek(out T value);

            Assert.False(res);
            Assert.Equal(value, default);
            Assert.Empty(queue);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void TryDequeue_WhenQueueNotEmpty_ShoudReturnTrueAndPutValueInParametrVariableWithRemoving<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            var res = queue.TryDequeue(out T value);

            Assert.True(res);
            Assert.Equal(value, objects[0]);
            Assert.Equal(queue.Count, objects.Length - 1);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void TryDequeue_WhenQueuóEmpty_ShoudReturnFalseAndPutDefaultValueInParametrVariable<T>(Queue<T> queue)
        {
            var res = queue.TryDequeue(out T value);

            Assert.False(res);
            Assert.Equal(value, default);
            Assert.Empty(queue);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetEnumerator_ShoudReturnElemntInCorrectOrder<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            var enumerator = queue.GetEnumerator();

            for(int i = 0; i < objects.Length; i++) 
            {
                enumerator.MoveNext();
                Assert.Equal(enumerator.Current, objects[i]);
            }
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void GetEnumerator_WhenQueueEmpty_MoveNextShoudReturnFalse<T>(Queue<T> queue)
        {
            var enumerator = queue.GetEnumerator();
            Assert.False(enumerator.MoveNext());
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CopyTo_ShoudCopiesElements<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            var array = new T[objects.Length];

            queue.CopyTo(array, 0);

            Assert.Equal(objects, array);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CopyTo_ShoudStartsAtCorectIndex<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);
            var array = new T[objects.Length + 2];

            queue.CopyTo(array, 1);

            Assert.Equal(default, array[0]);
            Assert.Equal(objects, array[1..(array.Length-1)]);
            Assert.Equal(default, array[array.Length-1]);
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void CopyTo_WhenIndexOutOfArrayRange_ShoudThrowIndexOutOfRangeExeption<T>(Queue<T> queue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => queue.CopyTo(new int[5], -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => queue.CopyTo(new int[5], 5));
        }

        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CopyTo_WhenDestinationArrayHasNotEnoughSpace_ShoudThrowArgumentException<T>(T[] objects)
        {
            var queue = new Queue<T>(objects);

            Assert.Throws<ArgumentException>(() => queue.CopyTo(new T[objects.Length-2], 0));
        }

        [Theory]
        [MemberData(nameof(TestDataClass.EmptyQueues), MemberType = typeof(TestDataClass))]
        public void CopyTo_WhenArrayMultidimensional_ShoudThrowArgumentExeption<T>(Queue<T> queue)
        {
            Assert.Throws<ArgumentException>(() => queue.CopyTo(new int[2, 2], 0));
        }
    }
}