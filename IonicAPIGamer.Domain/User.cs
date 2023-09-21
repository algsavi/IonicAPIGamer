namespace IonicAPIGamer.Domain;

public class User
{
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsActive { get; private set; }

    public User(string name, DateOnly birthDate)
    {
        if (IsAValidUser(name))
        {
            Name = name;
            BirthDate = birthDate;
            IsActive = true;
        }
    }

    public void InactiveUser()
    {
        IsActive = false;
    }

    private bool IsAValidUser(string name)
    {
        if (name.Length < 5)
            return false;

        return true;
    }
}