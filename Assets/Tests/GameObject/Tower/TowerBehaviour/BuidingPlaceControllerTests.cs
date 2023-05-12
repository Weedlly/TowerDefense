using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class BuildingPlaceControllerTests
{
    [Test]
    public void Test_ActiveInstance()
    {
        // Arrange
        var mockTransform = new GameObject().transform;
        var mockBuildingPlace1 = new GameObject();
        var mockBuildingPlace2 = new GameObject();
        mockBuildingPlace1.transform.position = new Vector3(0, 0, 0);
        mockBuildingPlace2.transform.position = new Vector3(1, 1, 0);
        BuidingPlaceController._buildingPlaceList = new List<GameObject>() { mockBuildingPlace1, mockBuildingPlace2 };
        
        // Act
        BuidingPlaceController.ActiveInstance(mockTransform);
        
        // Assert
        Assert.IsTrue(mockBuildingPlace1.activeSelf || mockBuildingPlace2.activeSelf);
    }

    [Test]
    public void Test_returnToBool()
    {
        // Arrange
        var mockBuildingPlace = new GameObject();
        mockBuildingPlace.SetActive(true);
        
        // Act
        BuidingPlaceController.returnToBool(mockBuildingPlace);
        
        // Assert
        Assert.IsFalse(mockBuildingPlace.activeSelf);
    }

    [Test]
    public void Test_MappingTowerPlaceData_NullList()
    {
        // Arrange
        BuidingPlaceController buildingPlaceController = new BuidingPlaceController();
        int stageId = 1;
        XMLControler._stageDataList = new StageListData();

        // Act
        buildingPlaceController.MappingTowerPlaceData(stageId);

        // Assert
        Assert.IsEmpty(buildingPlaceController.buildingPlaceList);
    }
    [Test]
    public void Test_MappingTowerPlaceData_EmptyList()
    {
        // Arrange
        BuidingPlaceController buildingPlaceController = new BuidingPlaceController();
        int stageId = 1;
        XMLControler._stageDataList = new StageListData();
        XMLControler._stageDataList.AddStageData(new StageData());

        // Act
        buildingPlaceController.MappingTowerPlaceData(stageId);

        // Assert
        Assert.IsEmpty(buildingPlaceController.buildingPlaceList);
    }

    [Test]
    public void Test_MappingTowerPlaceData_OneItem()
    {
        // Arrange
        BuidingPlaceController buildingPlaceController = new BuidingPlaceController();
        int stageId = 1;
        StageData stageData = new StageData();
        stageData.towerPlaceList = new List<TowerPlaceData>()
        {
            new TowerPlaceData() { towerPlaceId = 0, x = 1, y = 2 }
        };
        XMLControler._stageDataList = new StageListData();
        XMLControler._stageDataList.AddStageData(stageData);

        // Act
        buildingPlaceController.MappingTowerPlaceData(stageId);

        // Assert
        Assert.AreEqual(1, buildingPlaceController.buildingPlaceList.Count);
        Assert.AreEqual("BuildingContainer0", buildingPlaceController.buildingPlaceList[0].name);
        Assert.AreEqual(new Vector3(1, 2, 0), buildingPlaceController.buildingPlaceList[0].transform.position);
    }
    [Test]
    public void MappingTowerPlaceData_MultipleItems()
    {
        // Arrange
        BuidingPlaceController buildingPlaceController = new BuidingPlaceController();
        int stageId = 1;
        StageData stageData = new StageData();
        stageData.towerPlaceList = new List<TowerPlaceData>()
        {
            new TowerPlaceData() { towerPlaceId = 0, x = 1, y = 2 },
            new TowerPlaceData() { towerPlaceId = 1, x = 3, y = 4 },
            new TowerPlaceData() { towerPlaceId = 2, x = 5, y = 6 }
        };
        XMLControler._stageDataList = new StageListData();
        XMLControler._stageDataList.AddStageData(stageData);

        // Act
        buildingPlaceController.MappingTowerPlaceData(stageId);

        // Assert
        Assert.AreEqual(3, buildingPlaceController.buildingPlaceList.Count);
        Assert.AreEqual("BuildingContainer0", buildingPlaceController.buildingPlaceList[0].name);
        Assert.AreEqual(new Vector3(1f, 2f, 0f), buildingPlaceController.buildingPlaceList[0].transform.position);
        Assert.AreEqual("BuildingContainer1", buildingPlaceController.buildingPlaceList[1].name);
        Assert.AreEqual(new Vector3(3f, 4f, 0f), buildingPlaceController.buildingPlaceList[1].transform.position);
        Assert.AreEqual("BuildingContainer2", buildingPlaceController.buildingPlaceList[2].name);
        Assert.AreEqual(new Vector3(5f, 6f, 0f), buildingPlaceController.buildingPlaceList[2].transform.position);
    }
}