using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Tests
{
    public class TestDataClass
    {
        private static int[] ints = new int[] { 1, 2, 3, 4 };
        private static SimpleClass[] classes = new SimpleClass[] { new SimpleClass(), new SimpleClass(2), new SimpleClass(3, "3") };

        public static IEnumerable<object[]> EmptyQueues()
        {
            yield return new object[] { new Queue<int>() };
            yield return new object[] { new Queue<SimpleClass>() };
        }

        public static IEnumerable<object[]> TestData() 
        {
            yield return new object[] { ints };
            yield return new object[] { classes };
        }

        public class SimpleClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public SimpleClass(int id = 1, string name = "test")
            {
                Id = id;
                Name = name;
            }
        }
    }
}
