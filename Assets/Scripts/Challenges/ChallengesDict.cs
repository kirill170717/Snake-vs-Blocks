using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Challenges Dictionary", menuName = "Challenges/Challenges Dictionary", order = 50)]
public class ChallengesDict : ScriptableObject
{
    [Serializable]
    public class Challenge
    {
        public int key;
        public ChallengesTypes type;
        public string description;
        public int value;
        public int size;
    }

    public int key;
    public List<Challenge> challenges = new();
    
    public void Loading(int key)
    {
        if (!challenges.Exists(x => x.key == key))
        {
            challenges.Add(new Challenge() { key = key });
            Debug.Log("Added!");
        }
        else
            Debug.Log("The Key already exists!");
    }
    public void Deleting(int key)
    {
        if (challenges.Exists(x => x.key == key))
        {
            int keyId = challenges.FindIndex(x => x.key == key);
            challenges.RemoveAt(keyId);
            Debug.Log("Deleted!");
        }
        else
            Debug.Log("The Key doesn't exist!");
    }
}