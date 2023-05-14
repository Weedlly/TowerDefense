using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.Reflection;

public class GameControlTest
{
    // Load scene test
    [UnityTest]
    public IEnumerator Test_LoadScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GamePlay/GamePlay.unity");
        yield return null;
        GameObject gameControlObj = GameObject.Find("SpawnStageSystem");
        Assert.IsNotNull(gameControlObj);
    }

    [Test]
    public void Test_CoinIsEnough_EnoughCoin_ReturnsTrue()
    {
        // Arrange
        GameControl.IncreaseCoin(50);
        int coinToCheck = 30;
        
        // Act
        bool result = GameControl.CoinIsEnough(coinToCheck);
        
        // Assert
        Assert.IsTrue(result);
    }
    
    [Test]
    public void Test_CoinIsEnough_NotEnoughCoin_ReturnsFalse()
    {
        // Arrange
        GameControl.IncreaseCoin(20);
        int coinToCheck = 30;
        
        // Act
        bool result = GameControl.CoinIsEnough(coinToCheck);
        
        // Assert
        Assert.IsFalse(result);
    }
    
    [Test]
    public void Test_ReduceHealth_DecreasesHealthPoint()
    {
        // Arrange
        Type gameControlType = typeof(GameControl);
        FieldInfo healthPointField = gameControlType.GetField("_healthPoint", BindingFlags.NonPublic | BindingFlags.Static);
        GameControl gameControl = new GameControl();
        int initialHealthPoint = 10;
        
        // Act
        healthPointField.SetValue(gameControl, initialHealthPoint);
        GameControl.ReduceHealth();
        
        // Assert
        int updatedHealthPoint = (int)healthPointField.GetValue(gameControl);
        Assert.AreEqual(initialHealthPoint - 1, updatedHealthPoint);
    }
    
    [Test]
    public void Test_IncreaseCoin_IncreasesCoinPoint()
    {
        // Arrange
        Type gameControlType = typeof(GameControl);
        FieldInfo coinPointField = gameControlType.GetField("_coinPoint", BindingFlags.NonPublic | BindingFlags.Static);
        GameControl gameControl = new GameControl();
        int initialCoinPoint = 50;
        int coinToAdd = 30;
        
        // Act
        coinPointField.SetValue(gameControl, initialCoinPoint);
        GameControl.IncreaseCoin(coinToAdd);
        
        // Assert
        int updatedCoinPoint = (int)coinPointField.GetValue(gameControl);
        Assert.AreEqual(initialCoinPoint + coinToAdd, updatedCoinPoint);
    }
}
