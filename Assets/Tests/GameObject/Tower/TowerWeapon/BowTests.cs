using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BowTests
{
    [UnityTest]
    public IEnumerator Test_Bow_Start()
    {
        // Arrange
        Bow Bow = new Bow();

        // Acts
        Bow.Start();

        // Assert
        Assert.IsTrue(Bow._rangeTower._humans != null);
    }

    [UnityTest]
    public IEnumerator Test_Bow_Update()
    {
        // Arrange
        Bow Bow = new Bow();

        // Act
        Bow.Update();

        // Assert
        Assert.IsTrue(Bow._rangeTower._range == Bow._attackRange);
    }

    [UnityTest]
    public IEnumerator Test_Bow_Rotate()
    {
        // Arrange
        Bow Bow = new Bow();

        // Act
        Bow.Rotate();

        // Assert
        Assert.IsTrue(Bow._angle == 0f);
    }

    [UnityTest]
    public IEnumerator Test_Bow_Shoot()
    {
        // Arrange
        Bow Bow = new Bow();
        Bow._humans = new List<Human>();
        Bow._humans.Add(new Human());
        Bolt boltPrefab = Resources.Load<Bolt>("Bolt");

        // Act
        Bow.Shoot();

        // Assert
        Bolt bolt = GameObject.FindObjectOfType<Bolt>();
        Assert.IsNotNull(bolt);
        Assert.IsTrue(bolt.GetTarget() == Bow._humans[0]);
        Assert.IsTrue(bolt.GetDamage() == Bow._attackDame);
    }

    [Test]
    public void Test_Shoot_CreatesBoltWithCorrectPositionAndRotation()
    {
        // Arrange
        var Bow = new Bow();
        var humans = new List<Human> { new Human() };
        var boltPrefab = new Bolt();
        Bow._humans = humans;
        Bow._prefab = boltPrefab;
        var expectedPosition = Bow.transform.position;
        var expectedRotation = Quaternion.identity;
        
        // Act
        Bow.Shoot();
        var actualBolt = GameObject.FindObjectOfType<Bolt>();
        
        // Assert
        Assert.AreEqual(expectedPosition, actualBolt.transform.position);
        Assert.AreEqual(expectedRotation, actualBolt.transform.rotation);
    }

    [Test]
    public void Test_Rotate_RotatesTowerTowardsTarget()
    {
        // Arrange
        var Bow = new Bow();
        var human = new Human();
        var angle = 30f;
        Bow._humans = new List<Human> { human };
        Bow.transform.up = Vector3.up;
        human.transform.position = Bow.transform.position + new Vector3(1f, 1f, 0f);
        human.transform.up = Vector3.up;
        var expectedRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // Act
        Bow.Rotate();
        
        // Assert
        Assert.AreEqual(expectedRotation, Bow.transform.rotation);
    }

    [Test]
    public void Test_AttackController_NoTargets_SetsIsAttackToFalseAndResetsWaitTime()
    {
        // Arrange
        var Bow = new Bow();
        Bow._humans = new List<Human>();
        var expectedIsAttack = false;
        var expectedWaitTime = Bow._delayPerShot;
        
        // Act
        Bow.AttackControler();
        
        // Assert
        Assert.AreEqual(expectedIsAttack, Bow._isAttack);
        Assert.AreEqual(expectedWaitTime, Bow._waitTime);
    }

}
