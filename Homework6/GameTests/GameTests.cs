using NUnit.Framework;
using System;
using System.IO;
using Game;

namespace GameTests;

public class GameTests
{
    readonly EventLoop eventLoop = new();
    readonly Game.Game game = new();

    readonly string pathToStandartMap = "..\\GameTests\\..\\..\\..\\StandartMap.txt";
    readonly string pathToEmptyMap = "..\\GameTests\\..\\..\\..\\EmptyMap.txt";
    readonly string pathToIncorrectMap = "..\\GameTests\\..\\..\\..\\IncorrectMap.txt";

    [Test]
    public void StartCursorTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        var currentPosition = game.CurrentMatrixPosition;
        Assert.AreEqual((0, 3), currentPosition);
    }

    [Test]
    public void LeftMovementWithEmptySpaceAndWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (1, 3);
        for (var i = 0; i < 3; ++i)
        {
            game.OnLeft(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (1, 1));
    }

    [Test]
    public void LeftMovementWithConsoleWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (2, 2);
        for (var i = 0; i < 4; ++i)
        {
            game.OnLeft(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (2, 0));
    }

    [Test]
    public void RightMovementWithEmptySpaceAndWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (1, 1);
        for (var i = 0; i < 4; ++i)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (1, 3));
    }

    [Test]
    public void RightMovementWithConsoleWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (2, 4);
        for (var i = 0; i < 4; ++i)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (2, 6));
    }

    [Test]
    public void UpMovementWithEmptySpaceAndWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (2, 2);
        for (var i = 0; i < 3; ++i)
        {
            game.Up(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (1, 2));
    }

    [Test]
    public void UpMovementWithConsoleWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (0, 4);
        for (var i = 0; i < 2; ++i)
        {
            game.Up(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (0, 4));
    }

    [Test]
    public void DownMovementWithEmptySpaceAndWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (0, 1);
        for (var i = 0; i < 3; ++i)
        {
            game.Down(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (2, 1));
    }

    [Test]
    public void DownMovementWithConsoleWallTest()
    {
        game.CreateMatrixFromFileMap(pathToStandartMap);
        game.CurrentMatrixPosition = (2, 3);
        for (var i = 0; i < 3; ++i)
        {
            game.Down(this, EventArgs.Empty);
        }

        Assert.AreEqual(game.CurrentMatrixPosition, (3, 3));
    }

    [Test]
    public void EmptyMapTest()
    {
        Assert.Throws<InvalidDataException>(() => game.CreateMatrixFromFileMap(pathToEmptyMap));
    }

    [Test]
    public void IncorrectMapTest()
    {
        Assert.Throws<InvalidDataException>(() => game.CreateMatrixFromFileMap(pathToIncorrectMap));
    }
}