using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void AxeInit()
        {

        }

        [Test]
        public void AxeDurabilityShouldDropAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(5, 5);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(4, axe.DurabilityPoints);
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            //Arrange
            Axe axe = new Axe(5, 0);
            Dummy dummy = new Dummy(5, 5);

            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            StringAssert.AreEqualIgnoringCase("Axe is broken.", ex.Message);
        }
    }
}
