using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Images Dictionary", menuName = "Language/Images Dictionary", order = 50)]
public class DictionaryEditor : ScriptableObject
{
    [Serializable]
    public class ImgDict
    {
        public SystemLanguage language;
        public Sprite sprite;
    }

    [Serializable]
    public class DictList
    {
        public string key;
        public List<ImgDict> imagesList = new List<ImgDict>();
    }

    public string key;
    public List<DictList> imgList = new List<DictList>();
    public DictionaryEdit edit;
}

[CustomEditor(typeof(DictionaryEditor))]
public class DictionaryEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DictionaryEditor editor = (DictionaryEditor)target;
        editor.edit = (DictionaryEdit)EditorGUILayout.ObjectField("Script", editor.edit, typeof(DictionaryEdit), true);

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
        EditorGUILayout.PropertyField(serializedObject.FindProperty("imgList"), true);
        serializedObject.ApplyModifiedProperties();
    }
}