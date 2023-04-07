using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnPoint))]
public class DropdownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpawnPoint script = (SpawnPoint)target;

        GUIContent arrayLabel = new GUIContent("ObstacleType");
        script.arrayIdx = EditorGUILayout.Popup(arrayLabel, script.arrayIdx, script.ObstacleType);
        
    }
}