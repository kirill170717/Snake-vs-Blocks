using System;

[Serializable]
public class Data
{
    public static Data instance = new();

    public Settings settings = new();
    public Player player = new();

    public Data()
    {
        settings = new Settings()
        {
            music = true,
            effects = true,
            vibration = true,
            language = 0,
        };

        player = new Player()
        {
            defaultSnakeLength = 5,
            snakeLength = 0,
            record = 0,
            completedLevel = 0,
            unlockingPoints = 0,
            skin = 1,
        };
    }
}

[Serializable]
public class Player
{
    public int defaultSnakeLength;
    public int snakeLength;
    public int record;
    public int completedLevel;
    public int unlockingPoints;
    public int skin;
}

[Serializable]
public class Settings
{
    public bool music;
    public bool effects;
    public bool vibration;
    public int language;
}