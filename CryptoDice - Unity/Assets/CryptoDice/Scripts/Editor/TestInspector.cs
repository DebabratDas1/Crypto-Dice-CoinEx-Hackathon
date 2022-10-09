using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(TestCases))]
public class TestInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TestCases test = (TestCases)target;
        if (GUILayout.Button("Set Outcome"))
        {
            test.SetOutcome(test.outcome);
        }
    }
}