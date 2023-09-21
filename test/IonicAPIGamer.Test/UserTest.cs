using IonicAPIGamer.Domain;
using NUnit.Framework;

namespace IonicAPIGamer.Test;

public class UserTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("Andr�", 1987,4,27)]
    [TestCase("Jo�o", 1983, 3, 10)]
    public void Create_Valid_User(string name, int year, int month, int day)
    {
        DateOnly birthDate = new DateOnly(year, month, day);

        User user = new User(name, birthDate);

        Assert.Pass();
    }

    [Test]
    [TestCase("An", 1987, 4, 27)]
    [TestCase("Jo", 1983, 3, 10)]
    public void Create_Invalid_User(string name, int year, int month, int day)
    {
        DateOnly birthDate = new DateOnly(year, month, day);

        Assert.That(() => new User(name, birthDate), Throws.Exception
                    .With.Property("Message").EqualTo("Invalid User Data!"));
    }

    [Test]
    [TestCase("Andr�", 1987, 4, 27)]
    public void Check_If_User_Is_Active(string name, int year, int month, int day)
    {
        DateOnly birthDate = new DateOnly(year, month, day);

        User user = new User(name, birthDate);

        Assert.IsTrue(user.IsActive);
    }

    [Test]
    [TestCase("Andr�", 1987, 4, 27)]
    public void Check_If_User_Is_Inactive(string name, int year, int month, int day)
    {
        DateOnly birthDate = new DateOnly(year, month, day);

        User user = new User(name, birthDate);

        user.InactiveUser();

        Assert.IsFalse(user.IsActive);
    }
}