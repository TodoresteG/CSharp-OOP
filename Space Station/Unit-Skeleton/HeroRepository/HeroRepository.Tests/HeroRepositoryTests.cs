using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository repository;

    [SetUp]
    public void SetUpBeforeEachTest() 
    {
        this.repository = new HeroRepository();
    }

    [Test]
    public void ConstructorShouldInitializeRepository() 
    {
        //Act
        int actual = repository.Heroes.Count;

        //Assert
        int expected = 0;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CreateHeroShouldIncrementCount() 
    {
        var hero = new Hero("Pesho", 2);

        this.repository.Create(hero);

        int actual = this.repository.Heroes.Count;
        int expected = 1;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CreateShouldReturnString() 
    {
        var hero = new Hero("Pesho", 3);

        var actual = this.repository.Create(hero);
        var expected = $"Successfully added hero Pesho with level 3";

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CreateShouldThrowArgumentNullExceptionWhenHeroIsNull() 
    {
        Assert.Throws<ArgumentNullException>(() => 
        {
            this.repository.Create(null);
        });
    }

    [Test]
    public void CreateShouldThrowExceptionWhenHeroExists() 
    {
        var hero = new Hero("Pesho", 3);

        this.repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.repository.Create(hero);
        });
    }

    [Test]
    public void RemoveShouldReturnTrueWhenHeroIsRemoved() 
    {
        var hero = new Hero("Pesho", 3);

        this.repository.Create(hero);

        var actual = this.repository.Remove("Pesho");
        var expected = true;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveShouldThrowArgumentNullExceptionWhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Remove(null);
        });
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnHeroWithTheHighestLevel() 
    {
        var pesho = new Hero("Pesho", 2);
        var expected = new Hero("Tosho", 10);

        this.repository.Create(pesho);
        this.repository.Create(expected);

        var actual = this.repository.GetHeroWithHighestLevel();

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetHeroShouldReturnHeroWithGivenName() 
    {
        var hero = new Hero("Pesho", 2);

        this.repository.Create(hero);

        var actual = this.repository.GetHero("Pesho");

        Assert.AreEqual(hero, actual);
    }

    [Test]
    public void GetHeroShouldReturnNullWhenInvalidNameIsPassed() 
    {
        string expected = null;
        var actual = this.repository.GetHero("Test");

        Assert.AreEqual(expected, actual);
    }
}