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
        public int distanceBetweenRandom;
        public int repeatCount;
        public int averageValue;
        public int percentValue;
        public int blockSpawnChance;
        public int wallSpawnChance;
        public int circleSpawnChance;
    }
    public int levelsCount;
    public int beginKey;
    public int endKey;
    public int distanceBetweenFullLine;
    public int distanceBetweenRandom;
    public int repeatCount;
    public int averageValue;
    public int percentValue;
    public int blockSpawnChance;
    public int wallSpawnChance;
    public int circleSpawnChance;
    public List<Level> levels = new();
    

    public void LoadingCount(int levelsCount)
    {
        int c = levels.Count;
        for (int i = 0; i < levelsCount; i++)
        {
            c++;
            levels.Add(new Level() { key = c });
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

    public void ChangeValues(int beginKey, int endKey, int fullLine, int random, int repeatCount,
        int averageValue, int percentValue, int blockSpawnChance, int wallSpawnChance, int circleSpawnChance)
    {
        if (beginKey <= 0 || endKey <= 0 || fullLine <= 0 || random <= 0 || repeatCount <= 0 ||
        averageValue <= 0 || percentValue < 0 || blockSpawnChance < 0 || wallSpawnChance < 0 || circleSpawnChance < 0)
            Debug.Log("Only positive numbers!");
        else
        {
            if (beginKey >= endKey)
                Debug.Log("The level interval is not entered correctly!");
            else
            {
                int begin = levels.FindIndex(x => x.key == beginKey);
                int end = levels.FindIndex(x => x.key == endKey);

                for (int i = begin; i <= end; i++)
                {
                    levels[i].distanceBetweenFullLine = fullLine;
                    levels[i].distanceBetweenRandom = random;
                    levels[i].repeatCount = repeatCount;
                    levels[i].averageValue = averageValue;
                    levels[i].percentValue = percentValue;
                    levels[i].blockSpawnChance = blockSpawnChance;
                    levels[i].wallSpawnChance = wallSpawnChance;
                    levels[i].circleSpawnChance = circleSpawnChance;
                }
                Debug.Log("Modified!");
            }
        }
    }
}