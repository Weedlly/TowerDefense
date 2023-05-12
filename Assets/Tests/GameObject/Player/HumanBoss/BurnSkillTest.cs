using NUnit.Framework;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

public class BurneSkillTests
{
    // [Test]
    // public void Test_DameByExplored_EvilInExplosionRange_DealsDamage()
    // {
    //     // Arrange
    //     var evilGO = new GameObject();
    //     evilGO.tag = "Evil";
    //     evilGO.AddComponent<Evil>();
    //     var evil = evilGO.GetComponent<Evil>();
    //     evil._health = 100;
    //     evil.transform.position = new Vector2(0, 0);

    //     var burneSkillGO = new GameObject();
    //     var burneSkill = burneSkillGO.AddComponent<BurneSkill>();
    //     burneSkill._rangeExplore = 1;
    //     burneSkill.transform.position = new Vector2(2, 0);

    //     // Act
    //     burneSkill.DameByExplored();

    //     // Assert
    //     Assert.AreEqual(evil._health, 40); // Expect the evil to lose 60 health points
    // }

    // [Test]
    // public void Test_DameByExplored_EvilOutOfExplosionRange_DoesNotDealDamage()
    // {
    //     // Arrange
    //     var evilGO = new GameObject();
    //     evilGO.tag = "Evil";
    //     evilGO.AddComponent<Evil>();
    //     var evil = evilGO.GetComponent<Evil>();
    //     evil._health = 100;
    //     evil.transform.position = new Vector2(0, 0);

    //     var burneSkillGO = new GameObject();
    //     var burneSkill = burneSkillGO.AddComponent<BurneSkill>();
    //     burneSkill._rangeExplore = 0.5f;
    //     burneSkill.transform.position = new Vector2(2, 0);

    //     // Act
    //     burneSkill.DameByExplored();

    //     // Assert
    //     Assert.AreEqual(evil._health, 100); // Expect the evil to not lose any health points
    // }
}
