using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ISkillableTests
{
    GameObject prefab;
    Transform transform;
    Player target;

    [SetUp]
    public void Setup()
    {
        prefab = new GameObject();
        transform = new GameObject().transform;
        target = new Player();
    }

    [Test]
    public void Test_InsticSkill_CreatesAndDestroysBurneSkill()
    {
        // Arrange
        var insticSkill = new InsticSkill();

        // Act
        insticSkill.FetchSkill(prefab, transform, target);

        // Assert
        Assert.AreEqual(null, insticSkill);
    }

    [Test]
    public void Test_ActiveSkill_CreatesAndDestroysHellFire()
    {
        // Arrange
        var activeSkill = new ActiveSkill();

        // Act
        activeSkill.FetchSkill(prefab, transform, target);

        // Assert
        Assert.AreEqual(null, activeSkill);
    }
}
