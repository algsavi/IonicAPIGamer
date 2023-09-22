﻿namespace IonicAPIGamer.Domain.Entities;

public class Game
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    //To create Entityframework relationship
    public User User { get; set; }
    public int UserId { get; set; }

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
        if (name.Length < 5)
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
