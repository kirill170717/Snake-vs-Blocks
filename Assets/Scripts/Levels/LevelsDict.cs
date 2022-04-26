using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels Dictionary", menuName = "Levels/Levels Dictionary", order = 50)]
public class LevelsDict : ScriptableObject
{
    [Serializable]
    public class Level
    {
        public int key;
        public int distanceBetweenFullLine;
        public int distanceBetweenRandomLine;
        public int repeatCount;
        public int averageValue;
        public int percentValue;
        public int blockSpawnChance;
        public int wallSpawnChance;
        public int circleSpawnChance;
    }

    public int key;
    public List<Level> levels = new();
    public int levelsCount;

    public void Loading(int key)
    {
        if (!levels.Exists(x => x.key == key))
        {
            levels.Add(new Level() { key = key });
            Debug.Log("Added!");
        }
        else
            Debug.Log("The Key already exists!");
    }

    public void Deleting(int key)
    {
        if (levels.Exists(x => x.key == key))
        {
            int keyId = levels.FindIndex(x => x.key == key);
            levels.RemoveAt(keyId);
            Debug.Log("Deleted!");
        }
        else
            Debug.Log("The Key doesn't exist!");
    }

    public void LoadingCount(int levelsCount)
    {
        int c = levels.Count;
        for (int i = 0; i < levelsCount; i++)
        {
            c++;
            levels.Add(new Level() { key = c, distanceBetweenFullLine = 5, 
                distanceBetweenRandomLine = 5, repeatCount = 10, averageValue = 5, percentValue = 50,
                blockSpawnChance = 50, circleSpawnChance = 50, wallSpawnChance = 50 });
        }

        Debug.Log("Added!");
    }

    public void DeletingCount(int levelsCount)
    {
        if (levels.Count >= levelsCount)
        {
            int c = levels.Count;
            for (int i = 0; i < levelsCount; i++)
            {
                int keyId = levels.FindIndex(x => x.key == c);
                levels.RemoveAt(keyId);
                c--;
            }

            Debug.Log("Deleted!");
        }
        else
            Debug.Log("The entered number is greater than the number of levels!");
    }
}