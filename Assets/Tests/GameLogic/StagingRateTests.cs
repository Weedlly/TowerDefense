using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;

public class StageRatingTests
{
    private GameObject _oneStar;
    private GameObject _twoStar;
    private GameObject _threeStar;
    private StageRating _stageRating;

    [SetUp]
    public void Setup()
    {
        _oneStar = new GameObject();
        _twoStar = new GameObject();
        _threeStar = new GameObject();
        _stageRating = new StageRating(_oneStar, _twoStar, _threeStar);
    }

    [Test]
    public void Test_GetRatingStar_Returns_1_When_HealthPoint_Is_Less_Than_50_Percent()
    {
        int currentHealthPoint = 49;
        int healthPointMax = 100;

        int rating = _stageRating.GetRatingStar(currentHealthPoint, healthPointMax);

        Assert.AreEqual(1, rating);
    }

    [Test]
    public void Test_GetRatingStar_Returns_2_When_HealthPoint_Is_Less_Than_70_Percent()
    {
        int currentHealthPoint = 69;
        int healthPointMax = 100;

        int rating = _stageRating.GetRatingStar(currentHealthPoint, healthPointMax);

        Assert.AreEqual(2, rating);
    }

    [Test]
    public void Test_GetRatingStar_Returns_3_When_HealthPoint_Is_Full()
    {
        int currentHealthPoint = 60;
        int healthPointMax = 60;

        int rating = _stageRating.GetRatingStar(currentHealthPoint, healthPointMax);

        Assert.AreEqual(3, rating);
    }

    [Test]
    public void Test_GetRatingStar_Returns_0_When_HealthPoint_Is_Negative()
    {
        int currentHealthPoint = -10;
        int healthPointMax = 60;

        int rating = _stageRating.GetRatingStar(currentHealthPoint, healthPointMax);

        Assert.AreEqual(1, rating);
    }
}
