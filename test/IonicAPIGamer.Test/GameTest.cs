namespace IonicAPIGamer.Test;

public class GameTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("Mario", 10.9)]
    [TestCase("Crash", 9.9)]
    public void Create_Valid_Game(string name, decimal price)
    {
        Game game = new Game(name, price);

        Assert.Pass();
    }

    [Test]
    [TestCase("Mar", 10.9)]
    [TestCase("Cra", 9.9)]
    public void Create_Invalid_Game_Name(string name, decimal price)
    {
        Assert.That(() => new Game(name, price), Throws.Exception
                    .With.Property("Message").EqualTo("Invalid Game Data!"));
    }

    [Test]
    [TestCase("Mario", 0)]
    [TestCase("Crash", -1)]
    public void Create_Invalid_Game_Price(string name, decimal price)
    {
        Assert.That(() => new Game(name, price), Throws.Exception
                    .With.Property("Message").EqualTo("Invalid Game Data!"));
    }

    [Test]
    [TestCase("Mario", 10.9)]
    public void Check_If_Game_Is_Active(string name, decimal price)
    {
        Game game = new Game(name, price);

        Assert.IsTrue(game.IsActive);
    }

    [Test]
    [TestCase("Mario", 10.9)]
    public void Check_If_Game_Is_Inactive(string name, decimal price)
    {
        Game game = new Game(name, price);

        game.InactiveGame();

        Assert.IsFalse(game.IsActive);
    }
}
