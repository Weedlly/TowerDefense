using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FireRainTest
{
    // [Test]
    // public void Test_Start_ShouldSet_isDeploySkill_True()
    // {
    //     // Arrange
    //     var animator = new GameObject().AddComponent<Animator>();
    //     var fireRain = new GameObject().AddComponent<FireRain>();
    //     fireRain.circleOrigin = new GameObject().transform;
    //     fireRain.radius = 5f;
    //     fireRain._animatorFireRain = animator;
        
    //     // Act
    //     fireRain.Start();

    //     // Assert
    //     Assert.IsTrue(animator.GetBool("isDeploySkill"));
    // }

    // [Test]
    // public void Test_DetectColliders_ShouldLog_ColliderNames()
    // {
    //     // Arrange
    //     var collider1 = new GameObject("collider1").AddComponent<Collider2D>();
    //     var collider2 = new GameObject("collider2").AddComponent<Collider2D>();
    //     var fireRain = new GameObject().AddComponent<FireRain>();
    //     fireRain.circleOrigin = new GameObject().transform;
    //     fireRain.radius = 5f;
    //     fireRain.circleOrigin.position = Vector3.zero;
    //     collider1.transform.position = Vector3.zero;
    //     collider2.transform.position = Vector3.one;
        
    //     // Act
    //     fireRain.DetectColliders();

    //     // Assert
    //     Assert.That(LogAssert.log.Count == 2);
    //     Assert.IsTrue(LogAssert.log[0].message.Equals("collider1"));
    //     Assert.IsTrue(LogAssert.log[1].message.Equals("collider2"));
    // }

    // [Test]
    // public void Test_DameByExplored_ShouldReduceHealth_WithinRange()
    // {
    //     // Arrange
    //     var human1 = new GameObject("human1").AddComponent<Human>();
    //     var human2 = new GameObject("human2").AddComponent<Human>();
    //     var fireRain = new GameObject().AddComponent<FireRain>();
    //     fireRain.circleOrigin = new GameObject().transform;
    //     fireRain.radius = 5f;
    //     fireRain._rangeExplore = 10f;
    //     human1.transform.position = new Vector2(0f, 0f);
    //     human2.transform.position = new Vector2(20f, 20f);
    //     human1._health = 200f;
    //     human2._health = 200f;
        
    //     // Act
    //     fireRain.DameByExplored();

    //     // Assert
    //     Assert.AreEqual(human1._health, 100f);
    //     Assert.AreEqual(human2._health, 200f);
    // }
}