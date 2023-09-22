namespace IonicAPIGamer.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool IsActive { get; private set; }

    public List<Game> Games { get; private set; }

    private User() { }

    public User(string name, DateTime birthDate)
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
        if (name.Length < 3 || name.Length > 50)
            return false;

        return true;
    }
}