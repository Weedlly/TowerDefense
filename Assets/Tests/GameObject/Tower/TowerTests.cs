using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class TowerTests
{
    private TowerForTesting tower;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the TowerForTesting class for testing
        tower = new TowerForTesting();
    }

    [Test]
    public void IsAbleUpdateTower_LevelBelow2_ReturnsTrue()
    {
        // Arrange
        tower.Level = 1;

        // Act
        bool result = tower.IsAbleUpdateTower();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAbleUpdateTower_Level2_ReturnsFalse()
    {
        // Arrange
        tower.Level = 2;

        // Act
        bool result = tower.IsAbleUpdateTower();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void UpdateTower_IncreasesLevelBy1()
    {
        // Arrange
        int initialLevel = tower.Level;

        // Act
        tower.UpdateTower();

        // Assert
        Assert.AreEqual(initialLevel + 1, tower.Level);
    }

    [Test]
    public void MapTowerData_ValidIdAndLevel_ReturnsTrue()
    {
        // Arrange
        int validId = 1;
        int validLevel = 1;

        // Act
        bool result = tower.TestMapTowerData(validId, validLevel);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void MapTowerData_InvalidIdAndLevel_ReturnsFalse()
    {
        // Arrange
        int invalidId = -1;
        int invalidLevel = 0;

        // Act
        bool result = tower.TestMapTowerData(invalidId, invalidLevel);

        // Assert
        Assert.IsFalse(result);
    }

    // Derived class solely for testing the protected method
    public class TowerForTesting : Tower
    {
        public bool TestMapTowerData(int id, int level)
        {
            return MapTowerData(id, level);
        }
    }
}
