using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (MeshGenerator))]
public class MeshGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MeshGenerator generator = (MeshGenerator)target;
        
        if (DrawDefaultInspector())
        {
            generator.Initiate();
            generator.CreateShape();
            generator.Generate();
        }

        if (GUILayout.Button("Generate"))
        {
            generator.Initiate();
            generator.CreateShape();
            generator.Generate();
        }
    }
}
