using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TowerTroopTests
{
    private TowerTroop _towerTroop;
    private AssemblePoint _assemblePoint;

    [SetUp]
    public void Setup()
    {
        GameObject towerObject = new GameObject();
        _towerTroop = towerObject.AddComponent<TowerTroop>();
        _towerTroop._numberEvils = 5;

        GameObject assemblePointObject = new GameObject();
        _assemblePoint = assemblePointObject.AddComponent<AssemblePoint>();
        _towerTroop._assemblePoint = _assemblePoint;
    }

    [UnityTest]
    public IEnumerator TowerTroop_InitEvil_CreatesCorrectNumberOfEvils()
    {
        _towerTroop.InitEvil();

        yield return null;

        Assert.AreEqual(5, _towerTroop._evils.Count);
    }

    [UnityTest]
    public IEnumerator TowerTroop_SetEvilAssemblePoint_EvilAssemblePointIsWithin2UnitsOfAssemblePoint()
    {
        _towerTroop.InitEvil();

        _towerTroop.SetEvilAssemblePoint();

        yield return null;

        foreach (var evil in _towerTroop._evils)
        {
            float distance = Vector2.Distance(evil._assemblePoint, _assemblePoint.transform.position);
            Assert.LessOrEqual(distance, 2f);
        }
    }

    [UnityTest]
    public IEnumerator TowerTroop_SetupAfterRevive_EvilIsRevivedAndAddedToBattleController()
    {
        // Create a dead Evil
        Evil deadEvil = Instantiate(Resources.Load<Evil>("Evil"));
        deadEvil._isDie = true;
        deadEvil._timeReviveCounter = 0;
        _towerTroop._evils.Add(deadEvil);

        _towerTroop.SetupAfterRevive(deadEvil);

        yield return null;

        Assert.IsFalse(deadEvil._isDie);
        Assert.AreEqual(_towerTroop.transform.position, deadEvil.transform.position);
        Assert.IsTrue(BattleControler.GetEvils().Contains(deadEvil));
    }
}
