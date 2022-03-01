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

    public void Loading(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty!");
        else
        {
            if (!imgList.Exists(x => x.key == key))
            {
                imgList.Add(new DictList() { key = key });
                Debug.Log("Added!");
            }
            else
                Debug.Log("The Key already exists!");
        }
    }
    public void Deleting(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty!");
        else
        {
            if (imgList.Exists(x => x.key == key))
            {
                int keyId = imgList.FindIndex(x => x.key == key);
                imgList.RemoveAt(keyId);
                Debug.Log("Deleted!");
            }
            else
                Debug.Log("The Key doesn't exist!");
        }
    }
}

[CustomEditor(typeof(DictionaryEditor))]
public class DictionaryEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DictionaryEditor editor = (DictionaryEditor)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        editor.key = EditorGUILayout.TextField(editor.key);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            editor.Loading(editor.key);
        else if (GUILayout.Button("Delete"))
            editor.Deleting(editor.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("imgList"), true);
        serializedObject.ApplyModifiedProperties();
    }
}