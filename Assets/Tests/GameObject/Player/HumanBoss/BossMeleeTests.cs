using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class BossMeleeTests
{
    private BossMelee _boss;

    [SetUp]
    public void SetUp()
    {
        _boss = new BossMelee();
    }

    //[Test]
    // public void Test_Update_WhenHealthIsBelowMinHealth_DoesNotEmploySkill()
    // {
    //     _boss._health = 0f;
    //     _boss.Update();
    //     Assert.IsFalse(BossMelee._isBossEmploySkill);
    //     Assert.IsFalse(BossMelee._isBossEmployInsticSkill);
    //     Assert.IsFalse(BossMelee._isBossEmployActiveSkill);
    // }

    // [Test]
    // public void Test_Update_WhenHealthIsAboveMinHealth_DoesNotEmploySkill()
    // {
    //     _boss._health = 600f;
    //     _boss.Update();
    //     Assert.IsFalse(BossMelee._isBossEmploySkill);
    //     Assert.IsFalse(BossMelee._isBossEmployInsticSkill);
    //     Assert.IsFalse(BossMelee._isBossEmployActiveSkill);
    // }

    // [Test]
    // public void Test_Update_WhenHealthIsBelowHealthToDeploySkill_AndTargetIsNull_DoesNotEmploySkill()
    // {
    //     _boss._health = 400f;
    //     _boss.Update();
    //     Assert.IsFalse(BossMelee._isBossEmploySkill);
    //     Assert.IsFalse(BossMelee._isBossEmployInsticSkill);
    //     Assert.IsFalse(BossMelee._isBossEmployActiveSkill);
    // }

    // [Test]
    // public void Test_Update_WhenHealthIsBelowHealthToDeploySkill_AndTargetIsNotNull_EmploysInsticSkill()
    // {
    //     _boss._health = 400f;
    //     _boss._target = new GameObject();
    //     _boss.Update();
    //     Assert.IsTrue(BossMelee._isBossEmploySkill);
    //     Assert.IsTrue(BossMelee._isBossEmployInsticSkill);
    //     Assert.IsFalse(BossMelee._isBossEmployActiveSkill);
    // }

    // [Test]
    // public void Test_Update_WhenHealthIsAboveHealthToDeploySkill_AndTargetIsNotNull_EmploysActiveSkill()
    // {
    //     _boss._health = 600f;
    //     _boss._target = new GameObject();
    //     _boss.Update();
    //     Assert.IsTrue(BossMelee._isBossEmploySkill);
    //     Assert.IsFalse(BossMelee._isBossEmployInsticSkill);
    //     Assert.IsTrue(BossMelee._isBossEmployActiveSkill);
    // }

    // [Test]
    // public void Test_Update_WhenHealthIsAboveHealthToDeploySkill_AndTargetIsNull_DoesNotEmploySkill()
    // {
    //     _boss._health = 600f;
    //     _boss.Update();
    //     Assert.IsFalse(BossMelee._isBossEmploySkill);
    //     Assert.IsFalse(BossMelee._isBossEmployInsticSkill);
    //     Assert.IsFalse(BossMelee._isBossEmployActiveSkill);
    // }
}
