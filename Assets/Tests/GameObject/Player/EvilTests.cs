using NUnit.Framework;
using UnityEngine;

public class EvilTests
{
    private TestEvil evil;

    [SetUp]
    public void SetUp()
    {
        evil = new GameObject().AddComponent<TestEvil>();
        evil._assemblePoint = Vector2.zero;
        evil._movementSpeed = 5f;
    }

    [Test]
    public void Test_MoveDefault()
    {
        Vector2 startPosition = Vector2.one;
        evil.transform.position = startPosition;

        evil.TestMoveDefault();

        Vector2 expectedPosition = Vector2.MoveTowards(startPosition, evil._assemblePoint, Time.deltaTime * evil._movementSpeed);
        Vector2 result = evil.transform.position;
        Assert.AreEqual(expectedPosition, result);
    }

    private class TestEvil : Evil
    {
        public void TestMoveDefault()
        {
            MoveDefault();
        }
    }
}
