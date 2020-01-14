using System;
using System.Collections.Generic;
using CustomLinkedList;
using NUnit.Framework;

namespace Tests
{
    public class CustomLinkedListTests
    {
        private DynamicList<int> customList;

        [SetUp]
        public void Setup()
        {
            this.customList = new DynamicList<int>();
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void DynamicListShouldAddElementsCorrectly(int[] elements)
        {
            this.AddElements(elements);

            var expected = 3;
            var actual = this.customList.Count;

            Assert.AreEqual(expected, actual, "CustomList don't add elements correctly!");
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void DynamicListCountShouldReturnNumberOfElements(int[] elements)
        {
            this.AddElements(elements);

            var expected = 3;

            Assert.AreEqual(expected, this.customList.Count, "Count returns wrong value!");
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void GetValueShouldReturnNumberWhenIndexIsValid(int[] elements)
        {
            this.AddElements(elements);

            var expected = 1;
            var actual = 0;

            for (int i = 0; i < this.customList.Count; i++)
            {
                if (this.customList[i] == 2)
                {
                    actual = i;
                }
            }

            Assert.AreEqual(expected, actual, "Get value returns wrong element!");
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void GetValueShouldThrowExceptionWhenIndexIsInvalid(int[] elements)
        {
            this.AddElements(elements);

            var invalidIndex = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var element = this.customList[invalidIndex];
            }, "Invalid index!");
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void SetValueShouldSetNumberWhenIndexIsValid(int[] elements)
        {
            this.AddElements(elements);

            var expected = 10;
            this.customList[0] = expected;
            var actual = this.customList[0];

            Assert.AreEqual(expected, actual, "Set value sets wrong value!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void SetValueShouldThrowExceptionWhenIndexIsInvalid(int[] elements)
        {
            this.AddElements(elements);

            var invalidIndex = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var element = this.customList[invalidIndex];
            }, "Invalid index!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveAtShouldRemoveCorrectNumber(int[] elements)
        {
            this.AddElements(elements);

            var tempList = new List<int>() {2, 3};

            this.customList.RemoveAt(0);

            for (int i = 0; i < tempList.Count; i++)
            {
                Assert.AreEqual(this.customList[i], tempList[i], "RemoveAt removes elements wrong!");
            }
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveAtShouldReturnCorrectIndex(int[] elements)
        {
            this.AddElements(elements);

            var expected = 2;
            var actual = this.customList.RemoveAt(1);

            Assert.AreEqual(expected, actual, "RemoveAt returns wrong index!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveAtShouldDecreaseCount(int[] elements)
        {
            this.AddElements(elements);

            this.customList.RemoveAt(1);

            var expected = 2;
            var actual = this.customList.Count;

            Assert.AreEqual(expected, actual, "RemoveAt doesn't decrease count!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveAtShouldThrowExceptionWhenIndexIsInvalid(int[] elements)
        {
            this.AddElements(elements);

            var invalidIndex = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var element = this.customList.RemoveAt(invalidIndex);
            }, "Invalid index!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveMethodShouldRemoveElementCorrectly(int[] elements)
        {
            this.AddElements(elements);

            this.customList.Remove(3);

            var tempList = new List<int>() {1, 2};

            for (int i = 0; i < tempList.Count; i++)
            {
                Assert.AreEqual(this.customList[i], tempList[i], "Remove method remove elements wrong!");
            }
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveMethodShouldReturnCorrectIndex(int[] elements)
        {
            this.AddElements(elements);

            var expected = 1;
            var actual = this.customList.Remove(2);

            Assert.AreEqual(expected, actual, "Remove method doesn't returns correct index!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveMethodShouldReturnMinusOneWhenElementDoesNotExists(int[] elements)
        {
            this.AddElements(elements);

            var expected = -1;
            var actual = this.customList.Remove(6);

            Assert.AreEqual(expected, actual, "Remove method should return -1 when element is invalid!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void RemoveMethodShouldDecreaseCount(int[] elements)
        {
            this.AddElements(elements);

            this.customList.Remove(1);

            var expected = 2;
            var actual = this.customList.Count;

            Assert.AreEqual(expected, actual, "Remove doesn't decrease count!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void IndexOfShouldReturnCorrectIndexWhenElementExists(int[] elements)
        {
            this.AddElements(elements);

            var expected = 2;
            var actual = this.customList.IndexOf(3);

            Assert.AreEqual(expected, actual, "IndexOf doesn't return correct index!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void IndexOfShouldReturnMinusOneWhenElementDoesNotExists(int[] elements)
        {
            this.AddElements(elements);

            var expected = -1;
            var actual = this.customList.IndexOf(10);

            Assert.AreEqual(expected, actual, "IndexOf should return -1 when element doesn't exists!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void ContainsMethodShouldReturnTrueWhenElementIsFound(int[] elements)
        {
            this.AddElements(elements);

            var expected = true;
            var actual = this.customList.Contains(3);

            Assert.AreEqual(expected, actual, "Contains method should find an existing element!");
        }

        [Test]
        [TestCase(new int[] {1, 2, 3})]
        public void ContainsMethodShouldReturnFalseWhenElementIsNotFound(int[] elements)
        {
            this.AddElements(elements);

            var expected = false;
            var actual = this.customList.Contains(25);

            Assert.AreEqual(expected, actual, "Contains method should return false when element is not found!");
        }

        private void AddElements(int[] elements)
        {
            foreach (var number in elements)
            {
                this.customList.Add(number);
            }
        }
    }
}