using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ArrowTests
{
    [Test]
    public void Test_Update_CallsBaseUpdate()
    {
        // Arrange
        Arrow arrow = new GameObject().AddComponent<Arrow>();

        // Act
        arrow.Update();

        // Assert
        Assert.Pass("Base Update is called");
    }

    [Test]
    public void Test_Hitting_CallsBaseHitting()
    {
        // Arrange
        Arrow arrow = new GameObject().AddComponent<Arrow>();

        // Act
        arrow.Hitting();

        // Assert
        Assert.Pass("Base Hitting is called");
    }

    [Test]
    public void Test_Hitting_TargetIsNull_DoesNotReduceHealth()
    {
        // Arrange
        var arrow = new Arrow();
        arrow.SetDamage(10f);
        arrow.SetTarget(null);
        var initialHealth = 100f;
        var target = new Human();
        target.SetHealth(initialHealth);

        // Act
        arrow.Hitting();

        // Assert
        Assert.AreEqual(initialHealth, target.GetHealth());
    }

    [Test]
    public void Test_Hitting_TargetIsNotActive_DoesNotReduceHealth()
    {
        // Arrange
        var arrow = new Arrow();
        arrow.SetDamage(10f);
        var initialHealth = 100f;
        var target = new Human();
        target.SetHealth(initialHealth);
        target.gameObject.SetActive(false);
        arrow.SetTarget(target);

        // Act
        arrow.Hitting();

        // Assert
        Assert.AreEqual(initialHealth, target.GetHealth());
    }

    [Test]
    public void Test_Hitting_TargetIsActive_ReducesHealth()
    {
        // Arrange
        var arrow = new Arrow();
        arrow.SetDamage(10f);
        var initialHealth = 100f;
        var target = new Human();
        target.SetHealth(initialHealth);
        arrow.SetTarget(target);

        // Act
        arrow.Hitting();

        // Assert
        Assert.AreEqual(initialHealth - arrow._dame, target.GetHealth());
    }

}
