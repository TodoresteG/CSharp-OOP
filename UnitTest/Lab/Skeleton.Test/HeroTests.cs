using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Skeleton;

namespace Tests
{
    public class HeroTests
    {
        [Test]
        public void HeroShouldGainXpWhenTargetDies()
        {
            //Arrange
            IWeapon axe = new Axe(5, 5);
            ITarget dummy = new Dummy(5, 5);
            Hero hero = new Hero("Pesho", axe);

            //Act
            hero.Attack(dummy);

            //Assert
            Assert.AreEqual(5, hero.Experience);
        }
    }
}
