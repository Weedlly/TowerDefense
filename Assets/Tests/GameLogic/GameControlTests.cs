using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

public class GameControlTest
{
    // Load scene test
    [UnityTest]
    public IEnumerator Test_LoadScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GamePlay/GamePlay.unity");
        yield return null;
        GameObject gameControlObj = GameObject.Find("SpawnStageSystem");
        Assert.IsNotNull(gameControlObj);
    }

    // Reduce health test
    // [Test]
    // public void Test_ReduceHealth()
    // {
    //     GameControl.ReduceHealth();
    //     Assert.AreEqual(GameControl.CurrentHealth, GameControl.MaxHealth - 1);
    // }

    // Check winning test
    // [Test]
    // public void Test_CheckWinning()
    // {
    //     GameControl.MaxWave = 3;
    //     GameControl.CurrentWave = 3;
    //     GameControl.ReduceHealth();
    //     GameControl.CheckWinning();
    //     Assert.IsTrue(GameControl.WinContainer.activeSelf);
    // }

    // Check defeat test
    // [Test]
    // public void Test_CheckDefeat()
    // {
    //     GameControl.ReduceHealth();
    //     GameControl.CheckDefeat();
    //     Assert.IsTrue(GameControl.DefeatContainer.activeSelf);
    // }

    // Coin is enough test
    [Test]
    public void Test_CoinIsEnough()
    {
        GameControl.IncreaseCoin(10);
        bool result = GameControl.CoinIsEnough(5);
        Assert.IsTrue(result);
    }

    // // Coin is not enough test
    // [Test]
    // public void Test_CoinIsNotEnough()
    // {
    //     bool result = GameControl.CoinIsEnough(GameControl.CoinPointMax + 1);
    //     Assert.IsFalse(result);
    // }

    // // Decrease coin test
    // [Test]
    // public void Test_DecreaseCoin()
    // {
    //     GameControl.IncreaseCoin(10);
    //     GameControl.DecreaseCoin(5);
    //     Assert.AreEqual(GameControl.CoinPoint, 5);
    // }

    // // Increase coin test
    // [Test]
    // public void Test_IncreaseCoin()
    // {
    //     GameControl.IncreaseCoin(10);
    //     Assert.AreEqual(GameControl.CoinPoint, 10);
    // }
}
