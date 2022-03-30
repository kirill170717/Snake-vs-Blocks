using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skins Dictionary", menuName = "Skins/Skins Dictionary", order = 50)]

public class SkinsDict : ScriptableObject
{
    [Serializable]
    public class Skin
    {
        public string key;
        public int price;
        public Sprite head;
        public Sprite tail;
    }

    public string key;
    public List<Skin> skins = new();

    public void Loading(string key)
    {
        if (!skins.Exists(x => x.key == key))
        {
            skins.Add(new Skin() { key = key });
            Debug.Log("Added!");
        }
        else
            Debug.Log("The Key already exists!");
    }
    public void Deleting(string key)
    {
        if (skins.Exists(x => x.key == key))
        {
            int keyId = skins.FindIndex(x => x.key == key);
            skins.RemoveAt(keyId);
            Debug.Log("Deleted!");
        }
        else
            Debug.Log("The Key doesn't exist!");
    }
}