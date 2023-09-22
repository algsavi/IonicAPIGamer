using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Infra.Data.Context;
using IonicAPIGamer.Infra.Data.Repositories;
using Moq;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using IonicAPIGamer.Domain.Interfaces;
using IonicAPIGamer.Application.Services;

namespace IonicAPIGamer.Test;

public class GameServiceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task RetornaGameId_1()
    {
        var mockRepository = new Mock<IGameRepository>();
        var gameService = new GameService(mockRepository.Object);

        var game1 = new Game(1, "Mario", 10);
        var game2 = new Game(2, "Crash", 10);

        var games = new List<Game>();

        games.Add(game1);
        games.Add(game2);

        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(games);

        var gamesService = await gameService.GetGames();

        Assert.IsNotNull(games);
        
        Assert.AreEqual(games.Count, gamesService.Count());
    }

}