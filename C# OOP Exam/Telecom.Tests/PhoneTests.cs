using System;

namespace Telecom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PhoneTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Phone phone = new Phone("Test", "Qko test");

            string expectedMake = "Test";
            string expectedModel = "Qko test";

            Assert.AreEqual(expectedModel, phone.Model);
            Assert.AreEqual(expectedMake, phone.Make);
        }

        [Test]
        public void MakeShouldThrowExceptionWhenStringIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(null, "Test");
            });
        }

        [Test]
        public void ModelShouldThrowExceptionWhenStringIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("Test", null);
            });
        }

        [Test]
        public void CountShouldReturnCorrectCountOfPhoneBook()
        {
            Phone phone = new Phone("Test", "Ebasimo");

            int excpectedCount = 0;

            Assert.AreEqual(excpectedCount, phone.Count);
        }

        [Test]
        public void AddContactShouldAddContactToPhoneBook()
        {
            Phone phone = new Phone("Test", "Pisva mi");

            phone.AddContact("Todoreste", "9203403");

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void AddContactShouldThrowExceptionWhenPersonExistsInPhoneBook()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Phone phone = new Phone("Test", "Ne znam brat");

                phone.AddContact("Volen", "857239847389");
                phone.AddContact("Volen", "857239847389");
            });
        }

        [Test]
        public void CallShouldReturnCallingMessage()
        {
            Phone phone = new Phone("Test", "Vijda mu se kraq");

            phone.AddContact("Volen", "12345");

            string expected = "Calling Volen - 12345...";

            Assert.AreEqual(expected, phone.Call("Volen"));
        }

        [Test]
        public void CallShouldThrowExceptionWhenPersonDoesNotExistInPhoneBook()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Phone phone = new Phone("Test", "posledniqqqq");

                phone.Call("Todoreste");
            });
        }
    }
}