using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class RangeTowerTests
{
    [Test]
    public void Test_SetRangeScale_SetsScaleCorrectly()
    {
        RangeTower tower = new RangeTower();
        tower._range = 5f;
        tower.SetRangeScale();

        Assert.AreEqual(new Vector3(10f, 10f, 0f), tower.transform.localScale);
    }

    [Test]
    public void Test_OnTriggerStay2D_AddsHumanToHumansList_WhenHumanIsInRange()
    {
        RangeTower tower = new RangeTower();
        tower._range = 5f;
        Human human = new Human();
        human.gameObject.tag = "Human";
        human.transform.position = new Vector3(3f, 3f, 0f);

        tower.OnTriggerStay2D(human.GetComponent<Collider2D>());

        Assert.IsTrue(tower._humans.Contains(human));
    }

    [Test]
    public void Test_OnTriggerEnter2D_AddsHumanToHumansList_WhenHumanIsInRange()
    {
        RangeTower tower = new RangeTower();
        tower._range = 5f;
        Human human = new Human();
        human.gameObject.tag = "Human";
        human.transform.position = new Vector3(3f, 3f, 0f);

        tower.OnTriggerEnter2D(human.GetComponent<Collider2D>());

        Assert.IsTrue(tower._humans.Contains(human));
    }

    [Test]
    public void Test_IsTargetInRange_ReturnsTrue_WhenTargetIsInRange()
    {
        RangeTower tower = new RangeTower();
        tower._range = 5f;
        Human human = new Human();
        human.transform.position = new Vector3(3f, 3f, 0f);
        tower._humans.Add(human);

        Assert.IsTrue(tower.IsTargetInRange());
    }

    [Test]
    public void Test_IsTargetInRange_ReturnsFalse_WhenTargetIsOutOfRange()
    {
        RangeTower tower = new RangeTower();
        tower._range = 5f;
        Human human = new Human();
        human.transform.position = new Vector3(10f, 10f, 0f);
        tower._humans.Add(human);

        Assert.IsFalse(tower.IsTargetInRange());
    }
    
    [Test]
    public void Test_OnTriggerExit2D_DoesNotRemoveNonHumanColliderFromHumansList_WhenNonHumanColliderExitsRange()
    {
        // Arrange
        RangeTower rangeTower = new RangeTower();
        BoxCollider2D collider = new GameObject().AddComponent<BoxCollider2D>();
        collider.gameObject.tag = "Untagged";
        rangeTower._humans = new List<Human>();

        // Act
        rangeTower.OnTriggerExit2D(collider);

        // Assert
        Assert.IsEmpty(rangeTower._humans);
    }

    [Test]
    public void Test_OnTriggerExit2D_RemovesHumanFromHumansList_WhenHumanColliderExitsRange()
    {
        // Arrange
        RangeTower rangeTower = new RangeTower();
        BoxCollider2D collider = new GameObject().AddComponent<BoxCollider2D>();
        collider.gameObject.tag = "Human";
        rangeTower._humans = new List<Human>();
        Human human = collider.gameObject.AddComponent<Human>();
        rangeTower._humans.Add(human);

        // Act
        rangeTower.OnTriggerExit2D(collider);

        // Assert
        Assert.IsEmpty(rangeTower._humans);
    }

    [Test]
    public void Test_OnTriggerExit2D_DoesNotRemoveHumanFromHumansList_WhenNonHumanColliderExitsRange()
    {
        // Arrange
        RangeTower rangeTower = new RangeTower();
        BoxCollider2D collider = new GameObject().AddComponent<BoxCollider2D>();
        collider.gameObject.tag = "Untagged";
        rangeTower._humans = new List<Human>();
        Human human = collider.gameObject.AddComponent<Human>();
        rangeTower._humans.Add(human);

        // Act
        rangeTower.OnTriggerExit2D(collider);

        // Assert
        Assert.IsNotEmpty(rangeTower._humans);
        Assert.Contains(human, rangeTower._humans);
    }

}