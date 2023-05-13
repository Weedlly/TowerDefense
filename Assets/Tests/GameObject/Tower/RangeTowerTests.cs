using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RangeTowerTests
{
    private GameObject towerGameObject;
    private RangeTower rangeTower;
    private SpriteRenderer spriteRenderer;
    private GameObject target;
    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and attach the RangeTower component to it
        towerGameObject = new GameObject();
        rangeTower = towerGameObject.AddComponent<RangeTower>();

        // Add a SpriteRenderer component to the GameObject for testing
        spriteRenderer = towerGameObject.AddComponent<SpriteRenderer>();
        
        // Create a GameObject to act as the target
        target = new GameObject();
        target.transform.position = new Vector2(1f, 2f);
    }

    [Test]
    public void Test_ShowRange()
    {
        // Arrange
        spriteRenderer.sortingLayerName = "Invisible";

        // Act
        rangeTower.ShowRange();

        // Assert
        Assert.AreEqual("GameObject", spriteRenderer.sortingLayerName);
    }

    [Test]
    public void Test_HideRange()
    {
        // Arrange
        spriteRenderer.sortingLayerName = "GameObject";

        // Act
        rangeTower.HideRange();

        // Assert
        Assert.AreEqual("Invisible", spriteRenderer.sortingLayerName);
    }
    [Test]
    public void IsTargetInRange_TargetAtExactRange_ReturnsTrue()
    {
        // Arrange
        rangeTower._range = 5f;
        rangeTower._humans = new List<Human> { target.AddComponent<Human>() };
        target.transform.position = new Vector2(4f, 3f);

        // Act
        bool result = rangeTower.IsTargetInRange();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsTargetInRange_TargetOutsideRange_ReturnsFalse()
    {
        // Arrange
        rangeTower._range = 2f;
        rangeTower._humans = new List<Human> { target.AddComponent<Human>() };
        target.transform.position = new Vector2(5f, 5f);

        // Act
        bool result = rangeTower.IsTargetInRange();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsTargetInRange_MultipleTargetsInRange_ReturnsTrue()
    {
        // Arrange
        rangeTower._range = 4f;
        rangeTower._humans = new List<Human>
        {
            target.AddComponent<Human>(),
            new GameObject().AddComponent<Human>(),
            new GameObject().AddComponent<Human>()
        };
        target.transform.position = new Vector2(2f, 2f);

        // Act
        bool result = rangeTower.IsTargetInRange();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ShowRange_ChangesSortingLayerNameToGameObject()
    {
        // Arrange
        spriteRenderer.sortingLayerName = "SomeLayer";

        // Act
        rangeTower.ShowRange();

        // Assert
        Assert.AreEqual("GameObject", spriteRenderer.sortingLayerName);
    }

    [Test]
    public void HideRange_ChangesSortingLayerNameToInvisible()
    {
        // Arrange
        spriteRenderer.sortingLayerName = "SomeLayer";

        // Act
        rangeTower.HideRange();

        // Assert
        Assert.AreEqual("Invisible", spriteRenderer.sortingLayerName);
    }

}
