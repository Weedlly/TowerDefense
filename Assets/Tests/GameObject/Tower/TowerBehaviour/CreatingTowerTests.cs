using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class CreatingTowerTest
{
    [UnityTest]
    public IEnumerator TestCreate()
    {
        // Arrange
        CreatingTower creatingTower = new GameObject().AddComponent<CreatingTower>();
        creatingTower._prefab = new GameObject();
        creatingTower._buildButton = new GameObject().AddComponent<Button>();
        creatingTower._buildingPlaceContainer = new GameObject();
        creatingTower._buildingContainer = new GameObject().AddComponent<Image>();
        creatingTower._priceText = new GameObject().AddComponent<Text>();
        creatingTower._towerPrice = 10;

        // Act
        creatingTower.Create();

        // Assert
        yield return null;
        Assert.AreEqual(0, GameControl.Coin);
        Assert.IsFalse(creatingTower._buildingContainer.gameObject.activeSelf);
        Assert.IsTrue(BuidingPlaceController.isReturn);

        // Clean up
        GameObject.Destroy(creatingTower.gameObject);
    }

    [Test]
    public void TestResetState()
    {
        // Arrange
        CreatingTower creatingTower = new GameObject().AddComponent<CreatingTower>();
        creatingTower._buildingContainer = new GameObject().AddComponent<Image>();
        creatingTower._buildingPlaceContainer = new GameObject();

        // Act
        creatingTower.resetState();

        // Assert
        Assert.IsFalse(creatingTower._buildingContainer.gameObject.activeSelf);
        Assert.IsTrue(BuidingPlaceController.isReturn);

        // Clean up
        GameObject.Destroy(creatingTower.gameObject);
    }

    [Test]
    public void TestCoinIsEnough_EnoughCoin()
    {
        // Arrange
        CreatingTower creatingTower = new GameObject().AddComponent<CreatingTower>();
        creatingTower._towerPrice = 10;
        GameControl.Coin = 20;

        // Act
        bool result = creatingTower.CoinIsEnough();

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(Color.yellow, creatingTower._priceText.color);

        // Clean up
        GameObject.Destroy(creatingTower.gameObject);
    }

    [Test]
    public void TestCoinIsEnough_NotEnoughCoin()
    {
        // Arrange
        CreatingTower creatingTower = new GameObject().AddComponent<CreatingTower>();
        creatingTower._towerPrice = 10;
        GameControl.Coin = 5;

        // Act
        bool result = creatingTower.CoinIsEnough();

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(Color.red, creatingTower._priceText.color);

        // Clean up
        GameObject.Destroy(creatingTower.gameObject);
    }

    [Test]
    public void TestChangedPriceTextColor()
    {
        // Arrange
        CreatingTower creatingTower = new GameObject().AddComponent<CreatingTower>();
        creatingTower._priceText = new GameObject().AddComponent<Text>();

        // Act
        creatingTower.ChangedPriceTextColor(Color.red);

        // Assert
        Assert.AreEqual(Color.red, creatingTower._priceText.color);

        // Clean up
        GameObject.Destroy(creatingTower.gameObject);
    }

    [Test]
    public void TestSetupTowerPrice()
    {
        // Arrange
        CreatingTower creatingTower = new CreatingTower();
        GameObject instance = new GameObject();
        Bow bow = instance.AddComponent<Bow>();
        instance.transform.parent = creatingTower.transform;

        // Act
        creatingTower.SetupTowerPrice();

        // Assert
        Assert.AreEqual(10, creatingTower.GetTowerPrice());

        // Clean up
        DestroyImmediate(instance);
    }
}