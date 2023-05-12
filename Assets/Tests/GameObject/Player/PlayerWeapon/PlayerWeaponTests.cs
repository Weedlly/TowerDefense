using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerWeaponTests
{
    [Test]
    public void Test_Default_ChangesPosition()
    {
        var weaponObj = new GameObject("Weapon");
        var weapon = weaponObj.AddComponent<PlayerWeapon>();
        var startPos = weaponObj.transform.position;

        weapon.Default();

        Assert.AreNotEqual(startPos, weaponObj.transform.position);
    }

    [Test]
    public void Test_Down_ChangesPosition()
    {
        var weaponObj = new GameObject("Weapon");
        var weapon = weaponObj.AddComponent<PlayerWeapon>();
        var startPos = weaponObj.transform.position;

        weapon.Down();

        Assert.AreNotEqual(startPos, weaponObj.transform.position);
    }

    [Test]
    public void Test_Attack_ChangesPosition()
    {
        var weaponObj = new GameObject("Weapon");
        var weapon = weaponObj.AddComponent<PlayerWeapon>();
        var startPos = weaponObj.transform.position;

        weapon.Attack(true);

        Assert.AreNotEqual(startPos, weaponObj.transform.position);
    }
}
