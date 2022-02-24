using UnityEngine;

[CreateAssetMenu(fileName = "Player data", menuName = "Data/Player data", order = 50)]
public class PlayerData : ScriptableObject
{
    [Header("Player")]
    public int defaultSnakeLength;
    private int snakeLength;
    private int record;
    private int completedLevel;
    private int unlockingPoints;
    private int skin;

    [Header("Settings")]
    private bool music;
    private bool effects;
    private bool vibration;
    private SystemLanguage language;
}