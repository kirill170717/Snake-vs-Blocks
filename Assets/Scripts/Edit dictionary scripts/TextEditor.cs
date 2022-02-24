using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Edit Json", menuName = "Language/Edit Json", order = 50)]
public class TextEditor : ScriptableObject
{
    [Serializable]
    public class TextDict
    {
        public SystemLanguage language;
        public string text;
    }

    [Serializable]
    public class DictList
    {
        public string key;
        public List<TextDict> textsList = new List<TextDict>();
    }

    public string key;
    public List<DictList> txtList = new List<DictList>();
    public TextEdit edit;
}

[CustomEditor(typeof(TextEditor))]
public class TextEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        TextEditor editor = (TextEditor)target;
        editor.edit = (TextEdit)EditorGUILayout.ObjectField("Script", editor.edit, typeof(TextEdit), true);

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        editor.key = EditorGUILayout.TextField(editor.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Добавить"))
        {
            editor.edit.Loading(editor.key);
        }
        else if (GUILayout.Button("Удалить"))
        {
            editor.edit.Deleting(editor.key);
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("txtList"), true);
        serializedObject.ApplyModifiedProperties();
    }
}