using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelsDict))]
public class LevelsDictEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        LevelsDict level = (LevelsDict)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        level.key = EditorGUILayout.IntField(level.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            level.Loading(level.key);
        else if (GUILayout.Button("Delete"))
            level.Deleting(level.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Number of levels", GUILayout.MaxWidth(100));
        level.levelsCount = EditorGUILayout.IntField(level.levelsCount);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            level.LoadingCount(level.levelsCount); 
        if (GUILayout.Button("Delete"))
            level.DeletingCount(level.levelsCount);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("levels"), true);
        serializedObject.ApplyModifiedProperties();
    }
}