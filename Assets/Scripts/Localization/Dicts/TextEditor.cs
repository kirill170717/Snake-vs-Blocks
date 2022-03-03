using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Texts Dictionary", menuName = "Language/Texts Dictionary", order = 50)]
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

    public void Loading(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty");
        else
        {
            if (!txtList.Exists(x => x.key == key))
            {
                txtList.Add(new DictList() { key = key });
                Debug.Log("Added!");
            }
            else
                Debug.Log("The Key already exists");
        }
    }

    public void Deleting(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty");
        else
        {
            if (txtList.Exists(x => x.key == key))
            {
                int keyId = txtList.FindIndex(x => x.key == key);
                txtList.RemoveAt(keyId);
                Debug.Log("Deleted!");
            }
            else
                Debug.Log("The Key doesn't exist!");
        }
    }
}