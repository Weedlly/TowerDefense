using NUnit.Framework;
using UnityEngine;

public class WeaponBulletTests
{
    private class TestWeaponBullet : WeaponBullet
    {
        public bool RotateCalled { get; private set; } = false;

        public void CallRotate()
        {
            Rotate();
        }

        protected override void Rotate()
        {
            base.Rotate();
            RotateCalled = true;
        }
    }

    private TestWeaponBullet weaponBullet;

    [SetUp]
    public void SetUp()
    {
        GameObject gameObject = new GameObject();
        weaponBullet = gameObject.AddComponent<TestWeaponBullet>();
    }

    [Test]
    public void Rotate_ChangesRotationAccordingToTarget()
    {
        // Arrange
        Human target = new GameObject().AddComponent<Human>();
        Vector3 line = target.transform.position - weaponBullet.transform.position;
        float expectedAngle = Vector3.SignedAngle(weaponBullet.transform.up, line, weaponBullet.transform.forward);

        // Act
        weaponBullet.SetTarget(target);
        weaponBullet.CallRotate();

        // Assert
        Assert.AreEqual(expectedAngle, weaponBullet.transform.rotation.eulerAngles.z);
        Assert.IsTrue(weaponBullet.RotateCalled);
    }

    [Test]
    public void Hitting_ReducesTargetHealthAndDestroysBullet()
    {
        // Arrange
        Human target = new GameObject().AddComponent<Human>();
        float initialHealth = target._health;
        float damage = 10f;

        // Act
        weaponBullet.SetTarget(target);
        weaponBullet.SetDamage(damage);
        weaponBullet.Hitting();

        // Assert
        Assert.AreEqual(initialHealth - damage, target._health);
        Assert.IsTrue(weaponBullet.gameObject == null);
    }

    [Test]
    public void SetTarget_ChangesTarget()
    {
        // Arrange
        Human target = new GameObject().AddComponent<Human>();

        // Act
        weaponBullet.SetTarget(target);

        // Assert
        Assert.AreEqual(target, weaponBullet.GetTarget());
    }

    [Test]
    public void SetDamage_ChangesDamage()
    {
        // Arrange
        float damage = 20f;

        // Act
        weaponBullet.SetDamage(damage);

        // Assert
        Assert.AreEqual(damage, weaponBullet.GetDamage());
    }
}
