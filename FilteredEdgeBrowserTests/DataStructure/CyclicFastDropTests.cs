using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilteredEdgeBrowser.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteredEdgeBrowser.DataStructure.Tests
{
    [TestClass()]
    public class CyclicFastDropTests
    {
        public void AssertArrayEqual<T>(CyclicFastDrop<T> obj, T[] arr)
        {
            bool areSame = false;
            if (obj.Size() == arr.Length)
            {
                areSame = true;
                for (int i = 0; i < obj.Size(); i++)
                {
                    if (!obj[i].Equals(arr[i]))
                        areSame = false;
                }
            }

            Assert.IsTrue(areSame);
        }

        [TestMethod()]
        public void AddAndDropFutureTest_Empty_Same()
        {
            CyclicFastDrop<int> buffer = new CyclicFastDrop<int>(10);
            Assert.AreEqual(0, buffer.Size());

            buffer.AddAndDropFuture(1);
            Assert.AreEqual(1, buffer.Size());

            // Check we dont add the same
            buffer.AddAndDropFuture(1);
            Assert.AreEqual(1, buffer.Size());

            buffer.AddAndDropFuture(2);
            Assert.AreEqual(2, buffer.Size());
        }

        [TestMethod()]
        public void AddAndDropFutureTest_DropFuture()
        {
            CyclicFastDrop<int> buffer = new CyclicFastDrop<int>(10);

            buffer.AddAndDropFuture(1);
            buffer.AddAndDropFuture(2);
            buffer.AddAndDropFuture(3);

            buffer.CurrentPosition = 1;
            buffer.AddAndDropFuture(4);

            AssertArrayEqual<int>(buffer,new int[] { 1, 2, 4 });
        }

        [TestMethod()]
        public void AddAndDropFutureTest_MaxedOut()
        {
            CyclicFastDrop<int> buffer = new CyclicFastDrop<int>(3);

            buffer.AddAndDropFuture(1);
            buffer.AddAndDropFuture(2);
            buffer.AddAndDropFuture(3);
            buffer.AddAndDropFuture(4);
            buffer.AddAndDropFuture(5);

            AssertArrayEqual<int>(buffer, new int[] { 3 , 4 ,5 });
            Assert.AreEqual(buffer.CurrentPosition, 2);
        }

        [TestMethod()]
        public void AddAndDropFutureTest_MaxedOut_Drop()
        {
            CyclicFastDrop<int> buffer = new CyclicFastDrop<int>(3);

            buffer.AddAndDropFuture(1);
            buffer.AddAndDropFuture(2);
            buffer.AddAndDropFuture(3);
            buffer.AddAndDropFuture(4);
            buffer.AddAndDropFuture(5);

            // Should be [ 3 , 4 , 5 ] The last

            buffer.CurrentPosition--; // Point on 4

            buffer.AddAndDropFuture(6);
            buffer.AddAndDropFuture(7);

            AssertArrayEqual<int>(buffer, new int[] { 4, 6, 7 });

            Assert.AreEqual(buffer.CurrentPosition, 2);
        }
    }
}