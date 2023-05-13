using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;

using NUnit.Framework;

public class TowerWeaponTests : TowerWeapon
{
    [Test]
    public void SetTimeAttack_InitializesVariables()
    {
        // Arrange
        _attackSpeed = 2f;

        // Act
        SetTimeAttack();

        // Assert
        Assert.AreEqual(2.0f, _delayPerShot);
        Assert.AreEqual(0.2f, _waitShotAnimation);
        Assert.AreEqual(0.4f, _timeToAttack);
        Assert.AreEqual(0f, _waitTime);
    }

    [Test]
    public void AttackControler_AttackDisabled_CorrectlyUpdatesVariables()
    {
        // Arrange
        _humans = new List<Human>() { new Human() };
        _rangeTower = new RangeTower();
        _isAttack = false;
        _timeToAttack = 0f;
        _waitTime = 0f;
        _delayPerShot = 0.2f;
        _waitShotAnimation = 0f;
        _rangeTower._range = 5f;
        // Act
        AttackControler();

        // Assert
        Assert.IsFalse(_isAttack);
    }

    [Test]
    public void AttackControler_AttackEnabledAndInRange_PerformsAttack()
    {
        // Arrange
        _humans = new List<Human>() { new Human() };
        _rangeTower = new RangeTower();
        _isAttack = true;
        _timeToAttack = 0.4f;
        _waitTime = 0.2f;
        _delayPerShot = 0.4f;
        _waitShotAnimation = 0.2f;
        _rangeTower._range = 5f;

        // Act
        AttackControler();

        // Assert
        Assert.IsTrue(_isAttack);
    }

    [Test]
    public void AttackControler_NoTargetInRange_RemovesTarget()
    {
        // Arrange
        _humans = new List<Human>() { new Human() };
        _rangeTower = new RangeTower();
        _rangeTower._range = 0f;

        // Act
        AttackControler();

        // Assert
        Assert.IsEmpty(_humans);
    }
}
