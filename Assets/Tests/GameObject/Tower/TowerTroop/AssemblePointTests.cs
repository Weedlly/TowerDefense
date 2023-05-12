using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AssemblePointTests
{
    [Test]
    public void TestInitAssemblePoint()
    {
        GameObject obj = new GameObject();
        AssemblePoint assemblePoint = obj.AddComponent<AssemblePoint>();

        Vector2 towerPoint = new Vector2(2, 3);
        assemblePoint._towerPoint = towerPoint;

        assemblePoint.InitAssemblePoint();

        Vector2 expectedPos = RouteSet.FindNearestPoint(towerPoint);
        Vector2 actualPos = assemblePoint.transform.position;
        Assert.AreEqual(expectedPos, actualPos);
    }
    [Test]
    public void TestShowAssemblePoint()
    {
        GameObject obj = new GameObject();
        AssemblePoint assemblePoint = obj.AddComponent<AssemblePoint>();

        IEnumerator showAssemblePoint = assemblePoint.ShowAssemblePoint();
        while (showAssemblePoint.MoveNext()) { }

        string expectedLayerName = "Invisible";
        string actualLayerName = assemblePoint._assemblePointSprite.sortingLayerName;
        Assert.AreEqual(expectedLayerName, actualLayerName);
    }
    [Test]
    public void TestSetAssemblePoint()
    {
        // Arrange
        var assemblePoint = new GameObject().AddComponent<AssemblePoint>();
        assemblePoint._rangeToFire = 2f;
        assemblePoint.transform.position = new Vector2(0, 0);
        assemblePoint._towerPoint = assemblePoint.transform.position;
        assemblePoint._assemblePointSprite = assemblePoint.gameObject.AddComponent<SpriteRenderer>();
        assemblePoint._settingAssemblePoint = true;
        var camera = new GameObject().AddComponent<Camera>();
        camera.transform.position = new Vector3(0, 0, -10);
        camera.orthographic = true;
        camera.orthographicSize = 5;

        // Act
        var mousePosition = new Vector2(1, 1);
        var screenPosition = camera.WorldToScreenPoint(mousePosition);
        Input.simulatedMousePosition = screenPosition;
        Input.mouseScrollDelta = new Vector2(0, 1);
        Input.GetMouseButton(0);

        // Assert
        Assert.AreEqual(assemblePoint.transform.position, mousePosition);
        Assert.AreEqual(assemblePoint._settingAssemblePoint, false);
        Assert.AreEqual(assemblePoint._assemblePointSprite.sortingLayerName, "Invisible");
    }

}