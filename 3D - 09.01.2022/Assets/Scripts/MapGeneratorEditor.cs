using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator generator = (MapGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Clear"))
        {
            generator.Clear();
            generator.First();
        }

        if (GUILayout.Button("Generate"))
        {
            generator.First();
            generator.Initiate();
            generator.Generate();
        }
    }
}