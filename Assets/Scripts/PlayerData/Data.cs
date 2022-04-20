using System;
using System.Collections.Generic;
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
            unknown = false,
            life = 1,
            snakeLength = 5,
            recordLevel = 0,
            recordInfinite = 0,
            completedLevel = 0,
            coin = 0,
            skin = 0,
            purchaseSkins = new List<bool> { true },
            challenges = new List<Challenges>(),
        };
    }
}

[Serializable]
public class Challenges
{
    public int key;
    public bool complete = false;
}

[Serializable]
public class Player
{
    public bool unknown;
    public int life;
    public int snakeLength;
    public int recordLevel;
    public int recordInfinite;
    public int completedLevel;
    public int coin;
    public int skin;
    public List<bool> purchaseSkins;
    public List<Challenges> challenges;
}

[Serializable]
public class Settings
{
    public bool music;
    public bool effects;
    public bool vibration;
    public SystemLanguage language;
}