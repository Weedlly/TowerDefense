using NUnit.Framework;
using UnityEngine;
using UnityEditor.Animations;
using System.Reflection;

public class PlayerSkinTests
{
    [Test]
    public void ChangingSkin_ValidSkinOrder_ChangesAnimatorController()
    {
        // Arrange
        PlayerSkin playerSkin = new GameObject().AddComponent<PlayerSkin>();
        Animator animator = playerSkin.gameObject.AddComponent<Animator>();
        AnimatorController animatorController1 = new AnimatorController();
        AnimatorController animatorController2 = new AnimatorController();
        SetPrivateFieldValue(playerSkin, "_animatorControllers", new System.Collections.Generic.List<AnimatorController>()
        {
            animatorController1,
            animatorController2
        });
        int skinOrder = 1;

        // Act
        bool result = playerSkin.ChangingSkin(animator, skinOrder);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(animatorController2, animator.runtimeAnimatorController);
    }

    [Test]
    public void ChangingSkin_InvalidSkinOrder_ReturnsFalse()
    {
        // Arrange
        PlayerSkin playerSkin = new GameObject().AddComponent<PlayerSkin>();
        Animator animator = playerSkin.gameObject.AddComponent<Animator>();
        AnimatorController animatorController1 = new AnimatorController();
        AnimatorController animatorController2 = new AnimatorController();
        SetPrivateFieldValue(playerSkin, "_animatorControllers", new System.Collections.Generic.List<AnimatorController>()
        {
            animatorController1,
            animatorController2
        });
        int skinOrder = 2;

        // Act
        bool result = playerSkin.ChangingSkin(animator, skinOrder);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(null, animator.runtimeAnimatorController);
    }

    private void SetPrivateFieldValue<T>(object obj, string fieldName, T value)
    {
        var fieldInfo = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        fieldInfo.SetValue(obj, value);
    }
}
