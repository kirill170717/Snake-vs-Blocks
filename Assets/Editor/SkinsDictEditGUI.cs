using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SkinsDict))]
public class SkinsDictEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SkinsDict skins = (SkinsDict)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        skins.key = EditorGUILayout.TextField(skins.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            skins.Loading(skins.key);
        else if (GUILayout.Button("Delete"))
            skins.Deleting(skins.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("skins"), true);
        serializedObject.ApplyModifiedProperties();
    }
}