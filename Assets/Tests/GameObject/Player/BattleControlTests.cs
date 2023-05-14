using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;

public class BattleControlerTests
{
    [Test]
    public void Test_AddEvil()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        // Act
        BattleControler.AddEvil(player);
        BattleControler.AddHuman(player);
        // Assert
        Assert.AreEqual(1, BattleControler._evils.Count);
        Assert.Contains(player, BattleControler._humans);
    }

    [Test]
    public void Test_AddHuman()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        // Act
        BattleControler.AddHuman(player);
        BattleControler.AddEvil(player);
        // Assert
        Assert.AreEqual(1, BattleControler._humans.Count);
        Assert.Contains(player, BattleControler._evils);
    }

    [Test]
    public void Test_IsPlayerDie()
    {
        // Arrange
        BattleControler battleControler = new BattleControler();
        Player player = new Player();
        bool expectedResult = true;

        // Act
        bool result = (bool)typeof(BattleControler)
            .GetMethod("IsPlayerDie", BindingFlags.NonPublic | BindingFlags.Instance)
            .Invoke(battleControler, new object[] { player });

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Test_FindTarget()
    {
        // Arrange
        BattleControler battleControler = new BattleControler();
        Player searcher = new Player();
        List<Player> players = new List<Player>
        {
            new Player(),
            new Player(),
            new Player()
        };
        Player expectedTarget = players[0];

        // Act
        Player result = (Player)typeof(BattleControler)
            .GetMethod("FindTarget", BindingFlags.NonPublic | BindingFlags.Instance)
            .Invoke(battleControler, new object[] { searcher, players });

        // Assert
        Assert.AreEqual(expectedTarget, result);
    }
}
