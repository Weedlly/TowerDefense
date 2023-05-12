using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DemonSkillTests
{
    [Test]
    public void Test_DeployActiveSkill()
    {
        GameObject demonSkillGO = new GameObject();
        DemonSkill demonSkill = demonSkillGO.AddComponent<DemonSkill>();
        demonSkill.FR_Skill = Resources.Load<FireRain>("FireRain");

        demonSkill.setDeploySkill();

        Vector2 mousePos = new Vector2(1f, 1f);
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //wait for update to be called

        Assert.IsFalse(demonSkill.attackBlocked);

        Input.simulateMousePress(0);
        Input.mousePosition = mousePos;
       

        FireRain fr = GameObject.FindObjectOfType<FireRain>();
        Assert.IsNotNull(fr);
        Assert.AreEqual(fr.transform.position, worldMousePos);



        Assert.IsNull(GameObject.FindObjectOfType<FireRain>());
        Assert.IsFalse(demonSkill.attackBlocked);
    }

    [Test]
    public void Test_setDeploySkill()
    {
        GameObject demonSkillGO = new GameObject();
        DemonSkill demonSkill = demonSkillGO.AddComponent<DemonSkill>();

        demonSkill.setDeploySkill();

        Assert.IsTrue(demonSkill.isDeploySkill);
        Assert.IsFalse(demonSkill.attackBlocked);
    }

    [Test]
    public void Test_DelayAttack()
    {
        GameObject demonSkillGO = new GameObject();
        DemonSkill demonSkill = demonSkillGO.AddComponent<DemonSkill>();

        demonSkill.attackBlocked = true;

        Assert.IsFalse(demonSkill.attackBlocked);
    }
}
