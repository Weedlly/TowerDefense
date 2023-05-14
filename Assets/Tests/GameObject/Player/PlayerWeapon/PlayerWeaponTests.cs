using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerWeaponTests
{
    [Test]
    public void Test_Attack_ChangesPosition()
    {
        var weaponObj = new GameObject("Weapon");
        var weapon = weaponObj.AddComponent<PlayerWeapon>();
        var startPos = weaponObj.transform.position;

        weapon.Attack(true);

        Assert.AreNotEqual(startPos, weaponObj.transform.position);
    }
    [Test]
    public void Default_ShouldMoveToNewPosition()
    {
        // Arrange
        PlayerWeapon weapon = new GameObject().AddComponent<PlayerWeapon>();
        Vector2 initialPosition = new Vector2(0f, 0f);
        weapon.transform.position = initialPosition;

        // Act
        weapon.Default();

        // Assert
        Vector3 newPosition = new Vector3(initialPosition.x - 0.25f, initialPosition.y);
        Assert.AreEqual(newPosition, weapon.transform.position);
    }

    [Test]
    public void Attack_WhenFlipYIsFalse_ShouldMoveToNewPosition()
    {
        // Arrange
        PlayerWeapon weapon = new GameObject().AddComponent<PlayerWeapon>();
        Vector2 initialPosition = new Vector2(0f, 0f);
        weapon.transform.position = initialPosition;
        bool flipY = false;

        // Act
        weapon.Attack(flipY);

        // Assert
        Vector2 newPosition = new Vector2(initialPosition.x + 0.25f, initialPosition.y);
        Vector2 result = new Vector2(weapon.transform.position.x, weapon.transform.position.y);
        Assert.AreEqual(newPosition, result);
    }
}
