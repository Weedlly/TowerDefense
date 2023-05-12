using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StoneTests {

    [Test]
    public void Hitting_NotExplored_NoDamageToHumans() {
        // Arrange
        Stone stone = new Stone();
        stone._rangeExplore = 5f;
        stone._isExplored = false;
        GameObject humanObj = new GameObject();
        humanObj.tag = "Human";
        humanObj.transform.position = new Vector2(10f, 10f);
        Human human = humanObj.AddComponent<Human>();
        human._health = 10f;

        // Act
        stone.Hitting();

        // Assert
        Assert.AreEqual(10f, human._health);
    }

    [Test]
    public void Hitting_Explored_DamageToHumansInRange() {
        // Arrange
        Stone stone = new Stone();
        stone._rangeExplore = 5f;
        stone._isExplored = true;
        GameObject humanObj = new GameObject();
        humanObj.tag = "Human";
        humanObj.transform.position = new Vector2(3f, 3f);
        Human human = humanObj.AddComponent<Human>();
        human._health = 10f;

        // Act
        stone.Hitting();

        // Assert
        Assert.AreEqual(8f, human._health);
    }

    [Test]
    public void Hitting_Explored_NoDamageToHumansOutOfRange() {
        // Arrange
        Stone stone = new Stone();
        stone._rangeExplore = 5f;
        stone._isExplored = true;
        GameObject humanObj = new GameObject();
        humanObj.tag = "Human";
        humanObj.transform.position = new Vector2(10f, 10f);
        Human human = humanObj.AddComponent<Human>();
        human._health = 10f;

        // Act
        stone.Hitting();

        // Assert
        Assert.AreEqual(10f, human._health);
    }
}
