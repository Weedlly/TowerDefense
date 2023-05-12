using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    Player _player;

    [SetUp]
    public void SetUp()
    {
        GameObject playerGameObject = new GameObject();
        _player = playerGameObject.AddComponent<Player>();
    }

    [Test]
    public void Test_SetTarget_TargetIsNull_TargetShouldBeNull()
    {
        _player.SetTarget(null);
        Assert.IsNull(_player._target);
    }

    [Test]
    public void Test_SetTarget_TargetIsActive_TargetShouldNotBeNull()
    {
        GameObject targetGameObject = new GameObject();
        Player targetPlayer = targetGameObject.AddComponent<Player>();

        _player.SetTarget(targetPlayer);

        Assert.IsNotNull(_player._target);

        Object.Destroy(targetGameObject);
    }

    [Test]
    public void Test_HealthReduce_ReduceHealthBy10_CurrentHealthShouldBe90()
    {
        _player._health = 100;
        _player.HealthReduce(10);
        Assert.AreEqual(_player._health, 90);
    }

    [Test]
    public void Test_HealthControl_HealthIsZero_ReturnFalse()
    {
        _player._health = 0;
        Assert.IsFalse(_player.HealthControl());
    }

    [Test]
    public void Test_HealthControl_HealthIsGreaterThanMaxHealth_CurrentHealthShouldBeEqualToMaxHealth()
    {
        _player._health = 150;
        _player._healthBar = new HealthBar();
        _player._healthBar.MaxHealth = 100;

        Assert.AreEqual(_player._healthBar.CurrentHealth, _player._healthBar.MaxHealth);
    }

    [Test]
    public void Test_IsTargetActive_TargetIsNull_ReturnFalse()
    {
        _player._target = null;
        Assert.IsFalse(_player.IsTargetActive());
    }

    [Test]
    public void Test_IsTargetActive_TargetIsActive_ReturnTrue()
    {
        GameObject targetGameObject = new GameObject();
        Player targetPlayer = targetGameObject.AddComponent<Player>();
        _player._target = targetPlayer;

        Assert.IsTrue(_player.IsTargetActive());

        Object.Destroy(targetGameObject);
    }

    [Test]
    public void Test_MoveToTarget_MoveTowardsTargetPlayer_CurrentPositionShouldBeCloserToTarget()
    {
        GameObject targetGameObject = new GameObject();
        targetGameObject.transform.position = new Vector3(10, 0, 0);
        Player targetPlayer = targetGameObject.AddComponent<Player>();
        _player._target = targetPlayer;

        Vector2 startPosition = _player.transform.position;

        _player.MoveToTarget();

        Assert.IsTrue(Vector2.Distance(startPosition, _player.transform.position) > Vector2.Distance(new Vector2(10, 0), _player.transform.position));

        Object.Destroy(targetGameObject);
    }

    [Test]
    public void Test_Attack_TargetInRange_TargetShouldTakeDamage()
    {
        GameObject targetGameObject = new GameObject();
        targetGameObject.transform.position = new Vector3(1, 0, 0);
        Player targetPlayer = targetGameObject.AddComponent<Player>();
        _player._target = targetPlayer;

        _player._attackDame = 10;

        _player.Attack();

        Assert.AreEqual(targetPlayer._health, 90);

        Object.Destroy(targetGameObject);
    }
}
