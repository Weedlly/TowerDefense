using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NightBorneSkillTests
{
    [Test]
    public void Test_SetTypeSkill_ActiveSkill_AddsActiveSkillComponent()
    {
        // Arrange
        var gameObject = new GameObject();
        var nightBorneSkill = gameObject.AddComponent<NightBorneSkill>();

        // Act
        nightBorneSkill.SetTypeSkill(SkillTypeEnum.ActiveSkill);

        // Assert
        Assert.IsTrue(gameObject.TryGetComponent<ActiveSkill>(out var activeSkill));
        Assert.IsNull(gameObject.GetComponent<InsticSkill>());
    }

    // [Test]
    // public void Test_SetTypeSkill_InsticSkill_AddsInsticSkillComponent()
    // {
    //     // Arrange
    //     var gameObject = new GameObject();
    //     var nightBorneSkill = gameObject.AddComponent<NightBorneSkill>();

    //     // Act
    //     nightBorneSkill.SetTypeSkill(SkillTypeEnum.InsticSkill);

    //     // Assert
    //     Assert.IsTrue(gameObject.TryGetComponent<InsticSkill>(out var insticSkill));
    //     Assert.IsNull(gameObject.GetComponent<ActiveSkill>());
    // }

    [Test]
    public void Test_Update_IsDeloyActiveSkillFalse_NoSkillDeployed()
    {
        // Arrange
        var gameObject = new GameObject();
        var nightBorneSkill = gameObject.AddComponent<NightBorneSkill>();

        // Act


        // Assert
        Assert.IsFalse(nightBorneSkill.IsDeloyActiveSkill);
    }

    [Test]
    public void Test_Update_IsDeloyActiveSkillTrueAndBossEmployActiveSkillTrue_HellfireDeployed()
    {
        // Arrange
        var gameObject = new GameObject();
        var nightBorneSkill = gameObject.AddComponent<NightBorneSkill>();
        var target = new GameObject().AddComponent<Player>();
        BossMelee._isBossEmployActiveSkill = true;
        nightBorneSkill._target = target;

        // Act
        nightBorneSkill.SetTypeSkill(SkillTypeEnum.ActiveSkill);
        nightBorneSkill.IsDeloyActiveSkill = true;
        nightBorneSkill.Update();


        // Assert
        Assert.IsTrue(GameObject.FindObjectOfType<HellFire>());
        UnityEngine.Object.DestroyImmediate(gameObject);
        UnityEngine.Object.DestroyImmediate(target.gameObject);
    }

    [Test]
    public void Test_Update_IsDeloyActiveSkillTrueAndBossEmployActiveSkillFalse_HellfireNotDeployed()
    {
        // Arrange
        var gameObject = new GameObject();
        var nightBorneSkill = gameObject.AddComponent<NightBorneSkill>();
        var target = new GameObject().AddComponent<Player>();
        BossMelee._isBossEmployActiveSkill = false;
        nightBorneSkill._target = target;

        // Act
        nightBorneSkill.SetTypeSkill(SkillTypeEnum.ActiveSkill);
        nightBorneSkill.IsDeloyActiveSkill = true;
        nightBorneSkill.Update();


        // Assert
        Assert.IsNull(GameObject.FindObjectOfType<HellFire>());
        UnityEngine.Object.DestroyImmediate(gameObject);
        UnityEngine.Object.DestroyImmediate(target.gameObject);
    }
 }
