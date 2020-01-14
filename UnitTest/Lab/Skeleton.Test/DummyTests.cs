using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            //Arrange
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(5, 5);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(0, dummy.Health);
        }

        [Test]
        public void DeadDummyShouldThrowExceptionWhenAttacked()
        {
            //Arrange
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(0, 5);

            //Arrange
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void DeadDummyShouldGiveXp()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 5);

            //Act
            var xp = dummy.GiveExperience();

            //Assert
            Assert.AreEqual(5, xp);
        }

        [Test]
        public void AliveDummyShouldNotGiveXp()
        {
            //Arrange
            Dummy dummy = new Dummy(5, 5);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
