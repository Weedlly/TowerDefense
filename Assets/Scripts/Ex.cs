using UnityEngine;
using UnityEditor;
public class Ex : MonoBehaviour
{
    public float value = 7.0f;
}

// A tiny custom editor for ExampleScript component
[CustomEditor(typeof(Ex))]
public class Exam : Editor
{
    // Custom in-scene UI for when ExampleScript
    // component is selected.
    public void OnSceneGUI()
    {
        var t = target as Ex;
        var tr = t.transform;
        var pos = tr.position;
        // display an orange disc where the object is
        var color = new Color(1, 0.8f, 0.4f, 1);
        Handles.color = color;
        Handles.DrawWireDisc(pos,  Vector3.forward, 12.0f);
        // display object "value" in scene
        GUI.color = color;
        Handles.Label(pos, t.value.ToString("F1"));
    }
}