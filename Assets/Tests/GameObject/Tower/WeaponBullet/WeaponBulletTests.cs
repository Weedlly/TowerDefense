using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WeaponBulletTest
{
    // Dummy human for testing
    private GameObject _humanGameObject;
    private Human _human;

    // Bullet and animator components for testing
    private WeaponBullet _bullet;
    private Animator _animator;

    [SetUp]
    public void Setup()
    {
        // Create a dummy human
        _humanGameObject = new GameObject();
        _human = _humanGameObject.AddComponent<Human>();

        // Create a bullet object and animator
        GameObject bulletObject = new GameObject();
        _bullet = bulletObject.AddComponent<WeaponBullet>();
        _animator = bulletObject.AddComponent<Animator>();
        _bullet._animator = _animator;

        // Set default values for the bullet
        _bullet._target = _human;
        _bullet._movingSpeed = 1.0f;
        _bullet._dame = 10.0f;
        _bullet._isTargetExist = true;
    }
    [Test]
    public void Test_HittingTarget_ReduceTargetHealth()
    {
        // Arrange
        float targetHealth = _human.GetHealth();
        float expectedHealth = targetHealth - _bullet._dame;

        // Act
        _bullet.Hitting();

        // Assert
        Assert.AreEqual(expectedHealth, _human.GetHealth());
    }
}
