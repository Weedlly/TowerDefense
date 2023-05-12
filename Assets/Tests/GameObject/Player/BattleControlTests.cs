using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleControlerTests
{
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    [SetUp]
    public void Setup()
    {
        // Tạo các đối tượng Player để sử dụng cho việc test
        player1 = new GameObject();
        player1.AddComponent<Player>();
        player1.GetComponent<Player>()._health = 50;
        player1.GetComponent<Player>()._rangeDetecting = 10f;

        player2 = new GameObject();
        player2.AddComponent<Player>();
        player2.GetComponent<Player>()._health = 100;
        player2.GetComponent<Player>()._rangeDetecting = 20f;

        player3 = new GameObject();
        player3.AddComponent<Player>();
        player3.GetComponent<Player>()._health = 75;
        player3.GetComponent<Player>()._rangeDetecting = 15f;

        player4 = new GameObject();
        player4.AddComponent<Player>();
        player4.GetComponent<Player>()._health = 0;
    }

    [Test]
    public void Test_AddEvil()
    {
        BattleControler.AddEvil(player1.GetComponent<Player>());
        Assert.AreEqual(1, BattleControler._evils.Count);
    }

    [Test]
    public void Test_AddHuman()
    {
        BattleControler.AddHuman(player2.GetComponent<Player>());
        Assert.AreEqual(1, BattleControler._humans.Count);
    }

    //[Test]
    // public void Test_IsPlayerDeadActive()
    // {
    //     Assert.IsTrue(BattleControler.IsPlayerDeadActive(player4.GetComponent<Player>()));
    //     Assert.IsFalse(BattleControler.IsPlayerDeadActive(player1.GetComponent<Player>()));
    // }

    // [Test]
    // public void Test_IsPlayerDie()
    // {
    //     Assert.IsTrue(BattleControler.IsPlayerDie(player4.GetComponent<Player>()));
    //     Assert.IsFalse(BattleControler.IsPlayerDie(player2.GetComponent<Player>()));
    // }

    // [Test]
    // public void Test_FindTarget()
    // {
    //     BattleControler.AddHuman(player1.GetComponent<Player>());
    //     BattleControler.AddHuman(player2.GetComponent<Player>());
    //     BattleControler.AddEvil(player3.GetComponent<Player>());

    //     Player target = BattleControler.FindTarget(player1.GetComponent<Player>(), BattleControler._evils);
    //     Assert.AreEqual(player3, target);

    //     target = BattleControler.FindTarget(player2.GetComponent<Player>(), BattleControler._evils);
    //     Assert.IsNull(target);

    //     target = BattleControler.FindTarget(player1.GetComponent<Player>(), BattleControler._humans);
    //     Assert.IsNull(target);

    // }
}
