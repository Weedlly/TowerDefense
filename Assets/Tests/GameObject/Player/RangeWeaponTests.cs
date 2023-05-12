using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RangeWeaponTest
{
    [Test]
    public void Test_SetTarget_Null_Target()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        Player target = null;

        // Act
        weapon.SetTarget(target);

        // Assert
        Assert.IsNull(weapon._target);
    }

    [Test]
    public void Test_SetTarget_Non_Null_Target()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        Player target = new Player();

        // Act
        weapon.SetTarget(target);

        // Assert
        Assert.AreEqual(target, weapon._target);
    }

    [Test]
    public void Test_SetDamage()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        float damage = 10.0f;

        // Act
        weapon.SetDamage(damage);

        // Assert
        Assert.AreEqual(damage, weapon._dame);
    }

    [UnityTest]
    public IEnumerator Test_Hitting_Target_Null()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        weapon.SetTarget(null);

        // Act
        weapon.Hitting();

        // Assert
        yield return null;
        Assert.IsNull(weapon._target);
    }

    [UnityTest]
    public IEnumerator Test_Hitting_Target_Non_Null()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        Player target = new Player();
        float initialHealth = target._health;
        weapon.SetTarget(target);
        weapon.SetDamage(10.0f);

        // Act
        weapon.Hitting();

        // Assert
        yield return null;
        Assert.AreEqual(initialHealth - 10.0f, target._health);
    }

    [Test]
    public void Test_SelfDestroy_Target_Exists()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        Player target = new Player();
        weapon.SetTarget(target);

        // Act
        weapon.SelfDestroy();

        // Assert
        Assert.IsTrue(weapon._isTargetExist);
    }

    [Test]
    public void Test_SelfDestroy_Target_Does_Not_Exist()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        weapon._isTargetExist = true;

        // Act
        weapon.SelfDestroy();

        // Assert
        Assert.IsFalse(weapon._isTargetExist);
    }

    [UnityTest]
    public IEnumerator Test_Moving_Target_Null()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        weapon.SetTarget(null);

        // Act
        weapon.Moving();

        // Assert
        yield return null;
        Assert.IsNull(weapon._target);
    }

    [UnityTest]
    public IEnumerator Test_Moving_Target_Non_Null()
    {
        // Arrange
        RangeWeapon weapon = new RangeWeapon();
        Player target = new Player();
        float initialDistance = Vector2.Distance(weapon.transform.position, target.transform.position);
        weapon.SetTarget(target);

        // Act
        weapon.Moving();

        // Assert
        yield return null;
        float distance = Vector2.Distance(weapon.transform.position, target.transform.position);
        Assert.Less(distance, initialDistance);
    }
}
