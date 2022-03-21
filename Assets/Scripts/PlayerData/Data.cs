using System;
using UnityEngine;

[Serializable]
public class Data
{
    public static Data instance;

    public Settings settings;
    public Player player;

    public Data()
    {
        settings = new Settings()
        {
            music = true,
            effects = true,
            vibration = true,
            language = SystemLanguage.English,
        };
        player = new Player()
        {
            life = 1,
            snakeLength = 5,
            scoreLevel = 0,
            scoreInfinite = 0,
            recordLevel = 0,
            recordInfinite = 0,
            completedLevel = 0,
            unlockPoints = 0,
            skin = 0,
        };
    }
}

[Serializable]
public class Player
{
    public int life;
    public int snakeLength;
    public int scoreLevel;
    public int scoreInfinite;
    public int recordLevel;
    public int recordInfinite;
    public int completedLevel;
    public int unlockPoints;
    public int skin;
}

[Serializable]
public class Settings
{
    public bool music;
    public bool effects;
    public bool vibration;
    public SystemLanguage language;
}