using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CatapultTests
{
    [UnityTest]
    public IEnumerator Test_Catapult_Start()
    {
        // Arrange
        Catapult Catapult = new Catapult();

        // Act
        Catapult.Start();

        // Assert
        Assert.IsTrue(Catapult._rangeTower._humans != null);
    }

    [UnityTest]
    public IEnumerator Test_Catapult_Update()
    {
        // Arrange
        Catapult Catapult = new Catapult();

        // Act
        Catapult.Update();

        // Assert
        Assert.IsTrue(Catapult._rangeTower._range == Catapult._attackRange);
    }

    [UnityTest]
    public IEnumerator Test_Catapult_Rotate()
    {
        // Arrange
        Catapult Catapult = new Catapult();

        // Act
        Catapult.Rotate();

        // Assert
        Assert.IsTrue(Catapult._angle == 0f);
    }

    [UnityTest]
    public IEnumerator Test_Catapult_Shoot()
    {
        // Arrange
        Catapult Catapult = new Catapult();
        Catapult._humans = new List<Human>();
        Catapult._humans.Add(new Human());
        Bolt boltPrefab = Resources.Load<Bolt>("Bolt");

        // Act
        Catapult.Shoot();

        // Assert
        Bolt bolt = GameObject.FindObjectOfType<Bolt>();
        Assert.IsNotNull(bolt);
        Assert.IsTrue(bolt.GetTarget() == Catapult._humans[0]);
        Assert.IsTrue(bolt.GetDamage() == Catapult._attackDame);
    }

    [Test]
    public void Test_Shoot_CreatesBoltWithCorrectPositionAndRotation()
    {
        // Arrange
        var Catapult = new Catapult();
        var humans = new List<Human> { new Human() };
        var boltPrefab = new Bolt();
        Catapult._humans = humans;
        Catapult._prefab = boltPrefab;
        var expectedPosition = Catapult.transform.position;
        var expectedRotation = Quaternion.identity;
        
        // Act
        Catapult.Shoot();
        var actualBolt = GameObject.FindObjectOfType<Bolt>();
        
        // Assert
        Assert.AreEqual(expectedPosition, actualBolt.transform.position);
        Assert.AreEqual(expectedRotation, actualBolt.transform.rotation);
    }

    [Test]
    public void Test_Rotate_RotatesTowerTowardsTarget()
    {
        // Arrange
        var Catapult = new Catapult();
        var human = new Human();
        var angle = 30f;
        Catapult._humans = new List<Human> { human };
        Catapult.transform.up = Vector3.up;
        human.transform.position = Catapult.transform.position + new Vector3(1f, 1f, 0f);
        human.transform.up = Vector3.up;
        var expectedRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // Act
        Catapult.Rotate();
        
        // Assert
        Assert.AreEqual(expectedRotation, Catapult.transform.rotation);
    }

    [Test]
    public void Test_AttackController_NoTargets_SetsIsAttackToFalseAndResetsWaitTime()
    {
        // Arrange
        var Catapult = new Catapult();
        Catapult._humans = new List<Human>();
        var expectedIsAttack = false;
        var expectedWaitTime = Catapult._delayPerShot;
        
        // Act
        Catapult.AttackControler();
        
        // Assert
        Assert.AreEqual(expectedIsAttack, Catapult._isAttack);
        Assert.AreEqual(expectedWaitTime, Catapult._waitTime);
    }

}
