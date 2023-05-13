using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class HumanTests
{
    private Human human;
    private LineRenderer lineRenderer;

    [SetUp]
    public void SetUp()
    {
        GameObject humanObject = new GameObject("Human");
        human = humanObject.AddComponent<Human>();

        GameObject lineRendererObject = new GameObject("LineRenderer");
        lineRenderer = lineRendererObject.AddComponent<LineRenderer>();
        human.SetRoute(lineRenderer);
    }

    [Test]
    public void Test_MoveDefault()
    {
        human.transform.position = new Vector2(0f, 0f);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector2(0f, 0f));
        lineRenderer.SetPosition(1, new Vector2(1f, 0f));

        Vector2 initialPosition = human.transform.position;
        int initialIndex = GetPrivateFieldValue<int>(human, "_currentPositionIndex");

        // Gọi phương thức MoveDefault thông qua reflection
        InvokeProtectedMethod(human, "MoveDefault");

        Vector2 newPosition = human.transform.position;
        int newIndex = GetPrivateFieldValue<int>(human, "_currentPositionIndex");

        Assert.AreEqual(initialPosition, newPosition);
        Assert.AreEqual(initialIndex + 1, newIndex);
    }

    [Test]
    public void Test_SetRoute_InitialPosition()
    {
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0, new Vector2(0f, 0f));
        lineRenderer.SetPosition(1, new Vector2(1f, 0f));
        lineRenderer.SetPosition(2, new Vector2(2f, 0f));

        human.SetRoute(lineRenderer);

        LineRenderer route = GetPrivateFieldValue<LineRenderer>(human, "_route");
        int lengthOfPath = GetPrivateFieldValue<int>(human, "_lengthOfPath");
        int currentPositionIndex = GetPrivateFieldValue<int>(human, "_currentPositionIndex");
        Vector2 initialPosition = human.transform.position;

        Assert.AreEqual(lineRenderer, route);
        Assert.AreEqual(3, lengthOfPath);
        Assert.AreEqual(0, currentPositionIndex);
        Assert.AreEqual(new Vector2(0f, 0f), initialPosition);
    }

    [Test]
    public void Test_ResetsPositionAndIndex()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector2(0f, 0f));
        lineRenderer.SetPosition(1, new Vector2(1f, 0f));

        SetPrivateFieldValue(human, "_lengthOfPath", 2);
        SetPrivateFieldValue(human, "_currentPositionIndex", 1);
        human.transform.position = new Vector2(1f, 0f);

        InvokeProtectedMethod(human, "ArrivedDestination");

        int currentPositionIndex = GetPrivateFieldValue<int>(human, "_currentPositionIndex");
        Vector2 newPosition = human.transform.position;

        Assert.AreEqual(1, currentPositionIndex);
        Assert.AreEqual(new Vector2(1f, 0f), newPosition);
    }

    private T GetPrivateFieldValue<T>(object obj, string fieldName)
    {
        FieldInfo fieldInfo = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        return (T)fieldInfo.GetValue(obj);
    }

    private void SetPrivateFieldValue<T>(object obj, string fieldName, T value)
    {
        FieldInfo fieldInfo = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        fieldInfo.SetValue(obj, value);
    }

    private void InvokeProtectedMethod(object obj, string methodName)
    {
        MethodInfo methodInfo = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        methodInfo.Invoke(obj, null);
    }
    
}
