using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class RouteSetTests
{
    [Test]
    public void Test_MappingGateData_WithValidStageId()
    {
        RouteSet routeSet = new RouteSet();
        int stageId = 1;

        routeSet.MappingGateData(stageId);

        List<LineRenderer> gates = routeSet.GetGatesOfStage(stageId);

        Assert.IsNotNull(gates);
        Assert.Greater(gates.Count, 0);
    }

    [Test]
    public void Test_MappingGateData_WithInvalidStageId()
    {
        RouteSet routeSet = new RouteSet();
        int stageId = -1;

        routeSet.MappingGateData(stageId);

        List<LineRenderer> gates = routeSet.GetGatesOfStage(stageId);

        Assert.IsNull(gates);
    }

    [Test]
    public void Test_GetGatesOfStage_WithValidStageId()
    {
        RouteSet routeSet = new RouteSet();
        int stageId = 1;

        List<LineRenderer> gates = routeSet.GetGatesOfStage(stageId);

        Assert.IsNotNull(gates);
        Assert.Greater(gates.Count, 0);
    }

    [Test]
    public void Test_WriteDownGateSetForStageWithNullGates()
    {
        // Arrange
        int stageId = 1;
        RouteSet.gates = null;

        // Act
        TestDelegate act = () => RouteSet.WriteDownGateSetForStage(stageId);

        // Assert
        Assert.Throws<NullReferenceException>(act);
    }

    [Test]
    public void Test_GetGatesOfStageWithNullSpriteRenderer()
    {
        // Arrange
        int stageId = 1;
        RouteSet routeSet = new GameObject().AddComponent<RouteSet>();
        routeSet.sr = null;

        // Act
        TestDelegate act = () => routeSet.GetGatesOfStage(stageId);

        // Assert
        Assert.Throws<NullReferenceException>(act);
    }

    [Test]
    public void Test_FindNearestPointWithNullGates()
    {
        // Arrange
        Vector2 point = new Vector2(1f, 1f);
        RouteSet.gates = null;

        // Act
        TestDelegate act = () => RouteSet.FindNearestPoint(point);

        // Assert
        Assert.Throws<NullReferenceException>(act);
    }
}   