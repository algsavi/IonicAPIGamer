namespace IonicAPIGamer.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsActive { get; private set; }

    public List<Game> Games { get; private set; }

    public User() { }

    public User(string name, DateOnly birthDate)
    {
        if (!IsAValidUser(name))
        {
            throw new Exception("Invalid User Data!");
        }

        Name = name;
        BirthDate = birthDate;
        IsActive = true;
    }

    public void InactiveUser()
    {
        IsActive = false;
    }

    private bool IsAValidUser(string name)
    {
        if (name.Length < 3)
            return false;

        return true;
    }
}