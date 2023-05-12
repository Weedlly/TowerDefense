using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class DemonChampionTests
{
    // [Test]
    // public void Test_Idle_Should_Set_CurrentBehavior_To_Idle_And_IsAttackState_To_False()
    // {
    //     // Arrange
    //     GameObject go = new GameObject();
    //     var demon = go.AddComponent<DemonChampion>();
    //     demon.currentBehavior = DemonBehavior.Moving;
    //     demon._isAttackState = true;

    //     // Act
    //     demon.Idle();

    //     // Assert
    //     Assert.AreEqual(DemonBehavior.Idle, demon.currentBehavior);
    //     Assert.IsFalse(demon._isAttackState);
    // }

    [Test]
    public void Test_CurrentBehaviorIsIdle()
    {
        // Arrange
        var demon = new GameObject().AddComponent<DemonChampion>();

        // Act
        var behavior = demon.CurrentBehavior;

        // Assert
        Assert.AreEqual(DemonBehavior.Idle, behavior);
    }

    // [Test]
    // public void Test_SetMovement()
    // {
    //     // Arrange
    //     var demon = new GameObject().AddComponent<DemonChampion>();

    //     // Act
    //     demon.SetMovement();

    //     // Assert
    //     Assert.True(demon._setMoving);
    // }

    // [Test]
    // public void Test_AddExperience_AfterTargetDies()
    // {
    //     // Arrange
    //     var demon = new GameObject().AddComponent<DemonChampion>();
    //     var target = new GameObject().AddComponent<Enemy>();
    //     target._health = 0;
    //     demon.SetTarget(target);

    //     // Act
    //     demon.Attack();

    //     // Assert
    //     Assert.AreEqual(5, demon._expSystem.CurrentExp);
    // }

    // [Test]
    // public void Test_SetAttack_WithTarget()
    // {
    //     // Arrange
    //     DemonChampion champion = new GameObject().AddComponent<DemonChampion>();
    //     Enemy enemy = new GameObject().AddComponent<Enemy>();
    //     champion.SetTarget(enemy);

    //     // Act
    //     champion.SetAttack();

    //     // Assert
    //     Assert.AreEqual(DemonBehavior.Attack, champion.CurrentBehavior);
    //     Assert.IsTrue(champion._isAttackState);
    // }

    // [Test]
    // public void Test_Update_WithNoTarget()
    // {
    //     // Arrange
    //     DemonChampion champion = new GameObject().AddComponent<DemonChampion>();
    //     Enemy enemy = new GameObject().AddComponent<Enemy>();
    //     champion.SetTarget(enemy);
    //     champion.SetAttack();
    //     enemy._health = 0;

    //     // Act
    //     champion.Update();

    //     // Assert
    //     Assert.AreEqual(DemonBehavior.Idle, champion.CurrentBehavior);
    //     Assert.IsFalse(champion._isAttackState);
    // }

    // [Test]
    // public void Test_UpgradeAndSetAttack()
    // {
    //     // Arrange
    //     DemonChampion champion = new GameObject().AddComponent<DemonChampion>();
    //     champion._expSystem = new ExpSystem();
    //     champion._expSystem.isLevelUp = true;

    //     // Act
    //     champion.Update();
    //     champion.SetAttack();

    //     // Assert
    //     Assert.AreEqual(DemonBehavior.Attack, champion.CurrentBehavior);
    //     Assert.IsTrue(champion._isAttackState);
    //     Assert.Greater(champion._attackDame, 0);
    //     Assert.Greater(champion._attackSpeed, 0);
    // }

}
