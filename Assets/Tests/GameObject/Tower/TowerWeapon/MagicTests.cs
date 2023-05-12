using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MagicTests
{
    [UnityTest]
    public IEnumerator Test_Magic_Start()
    {
        // Arrange
        Magic magic = new Magic();

        // Act
        magic.Start();

        // Assert
        Assert.IsTrue(magic._rangeTower._humans != null);
    }

    [UnityTest]
    public IEnumerator Test_Magic_Update()
    {
        // Arrange
        Magic magic = new Magic();

        // Act
        magic.Update();

        // Assert
        Assert.IsTrue(magic._rangeTower._range == magic._attackRange);
    }

    [UnityTest]
    public IEnumerator Test_Magic_Rotate()
    {
        // Arrange
        Magic magic = new Magic();

        // Act
        magic.Rotate();

        // Assert
        Assert.IsTrue(magic._angle == 0f);
    }

    [UnityTest]
    public IEnumerator Test_Magic_Shoot()
    {
        // Arrange
        Magic magic = new Magic();
        magic._humans = new List<Human>();
        magic._humans.Add(new Human());
        Bolt boltPrefab = Resources.Load<Bolt>("Bolt");

        // Act
        magic.Shoot();

        // Assert
        Bolt bolt = GameObject.FindObjectOfType<Bolt>();
        Assert.IsNotNull(bolt);
        Assert.IsTrue(bolt.GetTarget() == magic._humans[0]);
        Assert.IsTrue(bolt.GetDamage() == magic._attackDame);
    }

    [Test]
    public void Test_Shoot_CreatesBoltWithCorrectPositionAndRotation()
    {
        // Arrange
        var magic = new Magic();
        var humans = new List<Human> { new Human() };
        var boltPrefab = new Bolt();
        magic._humans = humans;
        magic._prefab = boltPrefab;
        var expectedPosition = magic.transform.position;
        var expectedRotation = Quaternion.identity;
        
        // Act
        magic.Shoot();
        var actualBolt = GameObject.FindObjectOfType<Bolt>();
        
        // Assert
        Assert.AreEqual(expectedPosition, actualBolt.transform.position);
        Assert.AreEqual(expectedRotation, actualBolt.transform.rotation);
    }

    [Test]
    public void Test_Rotate_RotatesTowerTowardsTarget()
    {
        // Arrange
        var magic = new Magic();
        var human = new Human();
        var angle = 30f;
        magic._humans = new List<Human> { human };
        magic.transform.up = Vector3.up;
        human.transform.position = magic.transform.position + new Vector3(1f, 1f, 0f);
        human.transform.up = Vector3.up;
        var expectedRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // Act
        magic.Rotate();
        
        // Assert
        Assert.AreEqual(expectedRotation, magic.transform.rotation);
    }

    [Test]
    public void Test_AttackController_NoTargets_SetsIsAttackToFalseAndResetsWaitTime()
    {
        // Arrange
        var magic = new Magic();
        magic._humans = new List<Human>();
        var expectedIsAttack = false;
        var expectedWaitTime = magic._delayPerShot;
        
        // Act
        magic.AttackControler();
        
        // Assert
        Assert.AreEqual(expectedIsAttack, magic._isAttack);
        Assert.AreEqual(expectedWaitTime, magic._waitTime);
    }

}
