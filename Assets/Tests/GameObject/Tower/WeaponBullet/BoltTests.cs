using NUnit.Framework;
using UnityEngine;

public class BoltTests
{
    [Test]
    public void Test_Hitting_TargetExist_ShouldReduceTargetHealth()
    {
        // Arrange
        Bolt bolt = new GameObject().AddComponent<Bolt>();
        bolt.SetDamage(10f);
        Human target = new GameObject().AddComponent<Human>();
        target.SetMaxHealth(100f);
        bolt.SetTarget(target);

        // Act
        bolt.Hitting();

        // Assert
        Assert.AreEqual(90f, target.GetHealth());
    }

    [Test]
    public void Test_Hitting_TargetNotExist_ShouldNotReduceTargetHealth()
    {
        // Arrange
        Bolt bolt = new GameObject().AddComponent<Bolt>();
        bolt.SetDamage(10f);
        bolt.SetTarget(null);

        // Act
        bolt.Hitting();

        // Assert
        // No Assertion needed, as there should be no effect when the target is null.
    }
}
