using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameSpeedControllerTests
{
    //Kiểm tra xem khi GAME_SPEED được đặt về giá trị mặc định (Default), hàm ChangeGameSpeed() có đặt Time.timeScale về 1 hay không.
    [Test]
    public void Test_ChangeGameSpeed_SetToDefault_ShouldSetTimeScaleToOne()
    {
        // Arrange
        GameControler.GAME_SPEED = (float)GameSpeed.Double;
        GameObject go = new GameObject();
        var gameSpeedController = go.AddComponent<GameSpeedController>();

        // Act
        gameSpeedController.ChangeGameSpeed();

        // Assert
        Assert.AreEqual(1f, Time.timeScale);
    }
    //Kiểm tra xem khi GAME_SPEED được đặt về giá trị Double, hàm ChangeGameSpeed() có đặt Time.timeScale về 2 hay không.
    [Test]
    public void Test_ChangeGameSpeed_SetToDouble_ShouldSetTimeScaleToTwo()
    {
        // Arrange
        GameControler.GAME_SPEED = (float)GameSpeed.Default;
        GameObject go = new GameObject();
        var gameSpeedController = go.AddComponent<GameSpeedController>();

        // Act
        gameSpeedController.ChangeGameSpeed();

        // Assert
        Assert.AreEqual(2f, Time.timeScale);
    }
    //Kiểm tra xem khi GAME_SPEED được đặt về giá trị mặc định (Default), hàm ChangeGameSpeed() có đặt lại GAME_SPEED về Double hay không.
    [Test]
    public void Test_ChangeGameSpeed_SetToDefault_ShouldSetGameSpeedToDouble()
    {
        // Arrange
        GameControler.GAME_SPEED = (float)GameSpeed.Default;
        GameObject go = new GameObject();
        var gameSpeedController = go.AddComponent<GameSpeedController>();

        // Act
        gameSpeedController.ChangeGameSpeed();

        // Assert
        Assert.AreEqual((float)GameSpeed.Double, GameControler.GAME_SPEED);
    }
    //Kiểm tra xem khi GAME_SPEED được đặt về giá trị Double, hàm ChangeGameSpeed() có đặt lại GAME_SPEED về mặc định hay không.
    [Test]
    public void Test_ChangeGameSpeed_SetToDouble_ShouldSetGameSpeedToDefault()
    {
        // Arrange
        GameControler.GAME_SPEED = (float)GameSpeed.Double;
        GameObject go = new GameObject();
        var gameSpeedController = go.AddComponent<GameSpeedController>();

        // Act
        gameSpeedController.ChangeGameSpeed();

        // Assert
        Assert.AreEqual((float)GameSpeed.Default, GameControler.GAME_SPEED);
    }

}
