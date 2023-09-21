namespace IonicAPIGamer.Domain;

public class Game
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

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
        if(name.Length < 5)
            return false;

        if (price > 0)
            return false;

        return true;
    }

    public void InactiveGame()
    {
        IsActive = false;
    }
}
