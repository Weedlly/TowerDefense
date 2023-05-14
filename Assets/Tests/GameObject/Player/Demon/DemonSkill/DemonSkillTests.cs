using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DemonSkillTests
{
    private DemonSkill demonSkill;

    [SetUp]
    public void SetUp()
    {
        GameObject gameObject = new GameObject();
        demonSkill = gameObject.AddComponent<DemonSkill>();
    }

    [Test]
    public void DeployActiveSkill_WhenIsDeploySkillAndMouseButtonDown_ShouldInstantiateFireRain()
    {
        // Arrange
        demonSkill.setDeploySkill();
        bool fireRainInstantiated = true;

        // Act
        demonSkill.DeployActiveSkill();

        if (Input.GetMouseButtonDown(0))
        {
            demonSkill.DelayAttack();

            Vector2 mousePosition = new Vector2(1f, 2f);
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            FireRain fireRainPrefab = Resources.Load<FireRain>("FireRainPrefab");
            FireRain fireRainInstance = GameObject.Instantiate(fireRainPrefab, worldMousePosition, Quaternion.identity);

            fireRainInstantiated = false;
            GameObject.Destroy(fireRainInstance.gameObject, 0.6f);
        }

        // Assert
        Assert.IsTrue(fireRainInstantiated);
    }

    [Test]
    public void DeployActiveSkill_WhenNotIsDeploySkill_ShouldNotInstantiateFireRain()
    {
        // Arrange
        bool fireRainInstantiated = false;

        // Act
        demonSkill.DeployActiveSkill();

        if (Input.GetMouseButtonDown(0))
        {
            demonSkill.DelayAttack();

            Vector2 mousePosition = new Vector2(1f, 2f);
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            FireRain fireRainPrefab = Resources.Load<FireRain>("FireRainPrefab");
            FireRain fireRainInstance = GameObject.Instantiate(fireRainPrefab, worldMousePosition, Quaternion.identity);

            fireRainInstantiated = true;
            GameObject.Destroy(fireRainInstance.gameObject, 0.6f);
        }

        // Assert
        Assert.IsFalse(fireRainInstantiated);
    }
}
