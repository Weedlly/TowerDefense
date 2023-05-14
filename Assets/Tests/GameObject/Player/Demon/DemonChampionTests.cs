using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
public class DemonChampionTests
{
    private DemonChampion demonChampion;

    [SetUp]
    public void SetUp()
    {
        GameObject demonGameObject = new GameObject();
        demonChampion = demonGameObject.AddComponent<DemonChampion>();
    }

    [Test]
    public void Start_GetsChampionLevelAndStats()
    {
        Assert.AreEqual(DemonBehavior.Idle, demonChampion.CurrentBehavior);
    }

    [Test]
    public void Test_SetAttack()
    {
        demonChampion.SetAttack();
        Assert.AreEqual(DemonBehavior.Attack, demonChampion.CurrentBehavior);
    }

    [Test]
    public void Test_GetChampionState()
    {
        // Arrange
        ExpSystem expSystem = new ExpSystem();
        expSystem.SetAll(100, 200, 3);

        DemonChampion demonChampion = new DemonChampion();
        demonChampion._expSystem = expSystem;

        int expectedBaseHp = 150;

        // Accessing private field using reflection
        FieldInfo baseHpField = typeof(DemonChampion).GetField("_baseHp", BindingFlags.NonPublic | BindingFlags.Instance);
        baseHpField.SetValue(demonChampion, expectedBaseHp);

        // Act
        ChampionData actualData = demonChampion.GetChampionState();

        // Assert
        Assert.AreEqual(expectedBaseHp, actualData.health);
    }
}

