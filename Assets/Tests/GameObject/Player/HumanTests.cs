using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HumanTests
{
    [Test]
    public void Test_SetRoute_CorrectlySetsRoute()
    {
        // Arrange
        GameObject humanGameObject = new GameObject();
        Human human = humanGameObject.AddComponent<Human>();
        LineRenderer route = new GameObject().AddComponent<LineRenderer>();
        route.positionCount = 2;
        route.SetPosition(0, Vector3.zero);
        route.SetPosition(1, Vector3.one);

        // Act
        human.SetRoute(route);

        // Assert
        Assert.AreEqual(route, human._route);
        Assert.AreEqual(2, human._lengthOfPath);
        Assert.AreEqual(Vector3.zero, human.transform.position);
    }

    [Test]
    public void Test_MoveDefault_MovesToNextPosition()
    {
        // Arrange
        GameObject humanGameObject = new GameObject();
        Human human = humanGameObject.AddComponent<Human>();
        LineRenderer route = new GameObject().AddComponent<LineRenderer>();
        route.positionCount = 2;
        route.SetPosition(0, Vector3.zero);
        route.SetPosition(1, Vector3.one);
        human.SetRoute(route);
        human._currentPositionIndex = 0;

        // Act
        human.MoveDefault();

        // Assert
        Assert.AreEqual(Vector3.MoveTowards(human.transform.position, route.GetPosition(1), Time.deltaTime * human._movementSpeed), human.transform.position);
    }

    [Test]
    public void Test_ArrivedDestination_ResetsPosition()
    {
        // Arrange
        GameObject humanGameObject = new GameObject();
        Human human = humanGameObject.AddComponent<Human>();
        LineRenderer route = new GameObject().AddComponent<LineRenderer>();
        route.positionCount = 2;
        route.SetPosition(0, Vector3.zero);
        route.SetPosition(1, Vector3.one);
        human.SetRoute(route);
        human._currentPositionIndex = 1;

        // Act
        human.ArrivedDestination();

        // Assert
        Assert.AreEqual(0, human._currentPositionIndex);
        Assert.AreEqual(Vector3.zero, human.transform.position);
    }

    [Test]
    public void Test_SelfDestroy_ReturnsToPoolAndEarnsCoin()
    {
        // Arrange
        GameObject humanGameObject = new GameObject();
        Human human = humanGameObject.AddComponent<Human>();
        human._dropCoin = 10;

        // Act
        human.SelfDestroy();

        // Assert
        Assert.IsFalse(humanGameObject.activeSelf);
        Assert.AreEqual(10, GameControl.coin);
    }
}
