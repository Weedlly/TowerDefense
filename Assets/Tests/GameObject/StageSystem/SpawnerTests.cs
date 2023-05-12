using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class SpawnerTests
{
    [Test]
    public void Test_SpawnerSingleObject_SuccessfullySpawned()
    {
        // Arrange
        ObjectPooler pooler = new ObjectPooler();
        LineRenderer route = new LineRenderer();
        Spawner spawner = new Spawner(pooler, route);
        
        // Act
        spawner.SpawnerSingleObject();
        GameObject spawnedObject = pooler.GetObjectFromPool();
        
        // Assert
        Assert.IsNotNull(spawnedObject);
    }

    [Test]
    public void Test_SpawnerSingleObject_NoHumanComponent()
    {
        // Arrange
        ObjectPooler pooler = new ObjectPooler();
        LineRenderer route = new LineRenderer();
        Spawner spawner = new Spawner(pooler, route);
        
        // Act
        spawner.SpawnerSingleObject();
        GameObject spawnedObject = pooler.GetObjectFromPool();
        Human humanComponent = spawnedObject.GetComponent<Human>();
        
        // Assert
        Assert.IsNull(humanComponent);
    }

    [Test]
    public void Test_SpawnerSingleObject_HumanSetRoute()
    {
        // Arrange
        ObjectPooler pooler = new ObjectPooler();
        LineRenderer route = new LineRenderer();
        Spawner spawner = new Spawner(pooler, route);
        
        // Act
        spawner.SpawnerSingleObject();
        GameObject spawnedObject = pooler.GetObjectFromPool();
        Human humanComponent = spawnedObject.GetComponent<Human>();
        
        // Assert
        Assert.IsNotNull(humanComponent);
        Assert.AreEqual(route, humanComponent.GetRoute());
    }
}