using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ExpSystemTests
{
    private ExpSystem expSystem;

    [SetUp]
    public void SetUp()
    {
        expSystem = new ExpSystem();
    }

    [Test]
    public void AddExperience_EnoughExpToLevelUp_IncreaseLevelAndResetExp()
    {
        // Arrange
        expSystem.SetAll(0, 20, 1);
        
        // Act
        expSystem.AddExperience(25);

        // Assert
        Assert.AreEqual(2, expSystem.GetLevelNumber());
        Assert.AreEqual(0, expSystem.GetCurrentExp());
        Assert.AreEqual(40, expSystem.GetExpToNextLevel());
    }

    [Test]
    public void AddExperience_NotEnoughExpToLevelUp_KeepExpAndLevel()
    {
        // Arrange
        expSystem.SetAll(0, 20, 1);
        
        // Act
        expSystem.AddExperience(10);

        // Assert
        Assert.AreEqual(1, expSystem.GetLevelNumber());
        Assert.AreEqual(10, expSystem.GetCurrentExp());
        Assert.AreEqual(20, expSystem.GetExpToNextLevel());
    }

    [Test]
    public void GetAttackDameIncrease_Level1_ReturnBaseDame()
    {
        // Arrange
        float baseDame = 10f;
        expSystem.SetAll(0, 20, 1);

        // Act
        float result = expSystem.GetAttackDameIncrease(baseDame);

        // Assert
        Assert.AreEqual(baseDame, result);
    }

    [Test]
    public void GetAttackDameIncrease_Level2_ReturnIncreasedDame()
    {
        // Arrange
        float baseDame = 10f;
        expSystem.SetAll(0, 20, 2);

        // Act
        float result = expSystem.GetAttackDameIncrease(baseDame);

        // Assert
        Assert.AreEqual(15f, result);
    }

    [Test]
    public void GetAttackSpeedIncrease_Level1_ReturnBaseAttackSpeed()
    {
        // Arrange
        float baseAttackSpeed = 1.5f;
        expSystem.SetAll(0, 20, 1);

        // Act
        float result = expSystem.GetAttackSpeedIncrease(baseAttackSpeed);

        // Assert
        Assert.AreEqual(baseAttackSpeed, result);
    }

    [Test]
    public void GetAttackSpeedIncrease_Level3_ReturnIncreasedAttackSpeed()
    {
        // Arrange
        float baseAttackSpeed = 1.5f;
        expSystem.SetAll(0, 20, 3);

        // Act
        float result = expSystem.GetAttackSpeedIncrease(baseAttackSpeed);
        Assert.AreEqual(1.6f, result);
    }
}

