using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlaceTests
{
    [Test]
    public void Test_BuildingButtonHandle_OpenTowerMenu()
    {
        // Arrange
        var buildingPlace = new GameObject().AddComponent<BuildingPlace>();
        var towerMenu = new GameObject().AddComponent<Image>();
        buildingPlace._towerMenu = towerMenu;
        buildingPlace._buildingButton = new GameObject().AddComponent<Button>();

        // Act
        buildingPlace._buildingButton.onClick.Invoke();

        // Assert
        Assert.IsTrue(buildingPlace._towerMenu.gameObject.activeSelf);
        Assert.IsTrue(buildingPlace._isOpenBuilding);
    }

    [Test]
    public void Test_BuildingButtonHandle_CloseTowerMenu()
    {
        // Arrange
        var buildingPlace = new GameObject().AddComponent<BuildingPlace>();
        var towerMenu = new GameObject().AddComponent<Image>();
        buildingPlace._towerMenu = towerMenu;
        buildingPlace._buildingButton = new GameObject().AddComponent<Button>();

        // set towerMenu to active first
        towerMenu.gameObject.SetActive(true);

        // Act
        buildingPlace._buildingButton.onClick.Invoke();

        // Assert
        Assert.IsFalse(buildingPlace._towerMenu.gameObject.activeSelf);
        Assert.IsFalse(buildingPlace._isOpenBuilding);
    }
}
