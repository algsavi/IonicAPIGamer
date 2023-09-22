namespace IonicAPIGamer.Domain.Entities;

public class Game : Entity
{
   
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    

    public Game(int id, string name, decimal price)
    {
        if (!IsAValidGame(name, price))
        {
            throw new Exception("Invalid Game Data!");
        }

        Id = id;
        Name = name;
        Price = price;
        IsActive = true;
    }
    public Game(string name, decimal price)
    {
        if (!IsAValidGame(name, price))
        {
            throw new Exception("Invalid Game Data!");
        }

        Name = name;
        Price = price;
        IsActive = true;
    }

    private bool IsAValidGame(string name, decimal price)
    {
        if (name.Length < 5 || name.Length > 50)
            return false;

        if (price <= 0)
            return false;

        return true;
    }

    public void InactiveGame()
    {
        IsActive = false;
    }
}
