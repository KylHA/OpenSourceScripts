using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RopeCreator))]
public class RopeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RopeCreator ropeCreator = (RopeCreator)target;

        if (GUILayout.Button("Build Object"))
        {
            ropeCreator.Spawn();
        }
    }
}
