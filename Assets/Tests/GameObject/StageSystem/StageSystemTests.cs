using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class StageSystemTests
{
    [Test]
    public void Test_MappingStageData_ReturnsTrue()
    {
        StageSystem stageSystem = new StageSystem();
        bool result = stageSystem.MappingStageData(1, "");
        Assert.True(result);
    }

    [Test]
    public void Test_CallWave_ActivatesWaveSpawn()
    {
        StageSystem stageSystem = new StageSystem();
        stageSystem.CallWave();
        bool waveSpawned = false;
        // kiểm tra trong vòng 5 giây xem có phần tử nào được kích hoạt hay không
        for (int i = 0; i < 5; i++) {
            if (GameObject.FindWithTag("Enemy") != null) {
                waveSpawned = true;
                break;
            }
            Thread.Sleep(1000);
        }
        Assert.True(waveSpawned);
    }

    [Test]
    public void Test_SpawnObject_SpawnsCorrectTypeOfObject()
    {
        StageSystem stageSystem = new StageSystem();
        int typeId = 1;
        GameObject obj = new GameObject();
        obj.AddComponent<LineRenderer>();
        LineRenderer gate = obj.GetComponent<LineRenderer>();
        stageSystem.SpawnObject(typeId, gate);
        GameObject spawnedObj = GameObject.FindWithTag("Enemy");
        Assert.NotNull(spawnedObj);
        Assert.AreEqual(spawnedObj.GetComponent<Enemy>().Type, typeId);
    }

}