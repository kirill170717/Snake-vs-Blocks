using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChallengeDict))]
public class ChallengeDictEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ChallengeDict challenge = (ChallengeDict)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        challenge.key = EditorGUILayout.IntField(challenge.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            challenge.Loading(challenge.key);
        else if (GUILayout.Button("Delete"))
            challenge.Deleting(challenge.key);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("challenges"), true);
        serializedObject.ApplyModifiedProperties();
    }
}