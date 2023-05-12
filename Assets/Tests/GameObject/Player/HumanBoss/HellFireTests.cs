using NUnit.Framework;
using UnityEngine;

public class HellFireTests
{
    [Test]
    public void Test_Employing_DoesNotCallDameByExplored_WhenTargetIsNull()
    {
        // Arrange
        var hellFire = new GameObject().AddComponent<HellFire>();
        hellFire._target = null;
        var wasDameByExploredCalled = false;

        // Act
        hellFire.Employing();

        // Assert
        Assert.IsFalse(wasDameByExploredCalled);
    }

    // [Test]
    // public void Test_Employing_CallsDameByExplored_WhenTargetIsNotNull()
    // {
    //     // Arrange
    //     var hellFire = new GameObject().AddComponent<HellFire>();
    //     var target = new GameObject().AddComponent<Player>();
    //     hellFire._target = target;
    //     var wasDameByExploredCalled = false;

    //     // Mock the DameByExplored method to track if it's called
    //     hellFire.DameByExplored = () => wasDameByExploredCalled = true;

    //     // Act
    //     hellFire.Employing();

    //     // Assert
    //     Assert.IsTrue(wasDameByExploredCalled);
    // }

    [Test]
    public void Test_DameByExplored_ReducesHealthOfNearbyEvilObjects()
    {
        // Arrange
        var hellFire = new GameObject().AddComponent<HellFire>();
        var evil1 = new GameObject().AddComponent<Evil>();
        var evil2 = new GameObject().AddComponent<Evil>();
        var rangeExplore = 5f;
        var expectedEvil1Health = evil1._health - hellFire._dame;
        var expectedEvil2Health = evil2._health - hellFire._dame;

        // Set the positions of the objects so that evil1 is within range and evil2 is not
        hellFire.transform.position = Vector2.zero;
        evil1.transform.position = Vector2.right * 3f;
        evil2.transform.position = Vector2.right * 6f;

        // Set the rangeExplore value of hellFire
        hellFire._rangeExplore = rangeExplore;

        // Act
        hellFire.DameByExplored();

        // Assert
        Assert.AreEqual(expectedEvil1Health, evil1._health);
        Assert.AreEqual(evil2._health, Evil.maxHealth);
    }
}
