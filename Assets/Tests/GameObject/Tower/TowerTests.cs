using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class TowerTests
{
    [Test]
    public void Test_IsAbleUpdateTower()
    {
        Tower tower = new Tower();
        tower.Level = 1;

        bool result1 = tower.IsAbleUpdateTower();
        Assert.IsTrue(result1);

        tower.Level = 2;
        bool result2 = tower.IsAbleUpdateTower();
        Assert.IsFalse(result2);
    }

    [Test]
    public void Test_MapTowerData()
    {
        Tower tower = new Tower();
        int id = 1;
        int level = 1;

        TowerData towerData = new TowerData();
        towerData.name = "Tower";
        towerData.attackDame = 10f;
        towerData.attackSpeed = 0.5f;
        towerData.attackRange = 3f;
        towerData.health = 100f;
        towerData.price = 100;
        XMLControler._towerDataList.Add(towerData);

        bool result1 = tower.MapTowerData(id, level);
        Assert.IsTrue(result1);
        Assert.AreEqual("Tower", tower._name);
        Assert.AreEqual(10f, tower._attackDame);
        Assert.AreEqual(0.5f, tower._attackSpeed);
        Assert.AreEqual(3f, tower._attackRange);
        Assert.AreEqual(100f, tower._health);
        Assert.AreEqual(100, tower._price);
        Assert.AreEqual(30, tower._sellPrice);

        bool result2 = tower.MapTowerData(2, 1);
        Assert.IsFalse(result2);
    }

}