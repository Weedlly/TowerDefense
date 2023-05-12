using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class UpdateAndSellTests
{
    private GameObject _updateContainer;
    private Button _controlButton;
    private Button _updateButton;
    private Button _sellButton;
    private Button _exitButton;
    private Button _assembleButton;
    private Tower _currentTower;
    private Text _sellPrice;
    private Text _updatePrice;
    private AssemblePoint _assemblePoint;
    private UpdateAndSell _updateAndSell;

    [SetUp]
    public void Setup()
    {
        _updateContainer = new GameObject();
        _controlButton = new GameObject().AddComponent<Button>();
        _updateButton = new GameObject().AddComponent<Button>();
        _sellButton = new GameObject().AddComponent<Button>();
        _exitButton = new GameObject().AddComponent<Button>();
        _assembleButton = new GameObject().AddComponent<Button>();
        _currentTower = new GameObject().AddComponent<Tower>();
        _sellPrice = new GameObject().AddComponent<Text>();
        _updatePrice = new GameObject().AddComponent<Text>();
        _assemblePoint = new GameObject().AddComponent<AssemblePoint>();
        _updateAndSell = new GameObject().AddComponent<UpdateAndSell>();

        _updateAndSell._updateContainer = _updateContainer;
        _updateAndSell._controlButton = _controlButton;
        _updateAndSell._updateButton = _updateButton;
        _updateAndSell._sellButton = _sellButton;
        _updateAndSell._exitButton = _exitButton;
        _updateAndSell._assembleButton = _assembleButton;
        _updateAndSell._currentTower = _currentTower;
        _updateAndSell._sellPrice = _sellPrice;
        _updateAndSell._updatePrice = _updatePrice;
        _updateAndSell._assemblePoint = _assemblePoint;
    }

    [Test]
    public void UpdateTower_WithEnoughCoins_UpdatesTower()
    {
        // Arrange
        _currentTower.Price = 100;
        _currentTower.UpdateTower();
        GameControl.DecreaseCoin(100);

        // Act
        _updateAndSell.UpdateTower();

        // Assert
        Assert.AreEqual(200, _currentTower.Price);
    }

    [Test]
    public void UpdateTower_WithoutEnoughCoins_DoesNotUpdateTower()
    {
        // Arrange
        _currentTower.Price = 100;
        GameControl.DecreaseCoin(50);

        // Act
        _updateAndSell.UpdateTower();

        // Assert
        Assert.AreEqual(100, _currentTower.Price);
    }

    [Test]
    public void SellTower_IncreasesCoinsAndDestroysTower()
    {
        // Arrange
        _currentTower.SellPrice = 50;

        // Act
        _updateAndSell.SellTower();

        // Assert
        Assert.AreEqual(50, GameControl.Coins);
        Assert.IsNull(_currentTower.transform.parent);
    }

    [Test]
    public void Exit_SetsActiveToFalse()
    {
        // Act
        _updateAndSell.Exit();

        // Assert
        Assert.IsFalse(_updateAndSell.gameObject.activeSelf);
    }   
    [Test]
    public void AssemblePoint_SetsSettingAssemblePointToTrue()
    {
        // Set up the test by creating a new button and adding it to the _assembleButton field
        Button testButton = new Button();
        _updateAndSell.GetType().GetField("_assembleButton", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(_updateAndSell, testButton);

        // Call the AssemblePoint method
        _updateAndSell.AssemblePoint();

        // Verify that _assemblePoint._settingAssemblePoint is set to true
        Assert.IsTrue(_assemblePoint._settingAssemblePoint);
    }
}