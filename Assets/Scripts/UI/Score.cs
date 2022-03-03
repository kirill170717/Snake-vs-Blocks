using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TMP_Text scoreView;
    public TMP_Text skinsView;
    public TMP_Text recordView;
    public TMP_Text finalScore;
    public TMP_Text levelView;

    private int destroyPoints;
    private int unlockingPoints;
    private int recordLevel;
    private int recordInfinite;
    private int level;

    private void Awake() => instance = this;

    public void Update()
    {
        if (levelView.IsActive())
        {
            levelView.text = PlayerPrefs.GetInt("Level").ToString();
            recordLevel = destroyPoints;

            if (PlayerPrefs.GetInt("ScoreLevel") <= recordLevel)
                PlayerPrefs.SetInt("ScoreLevel", recordLevel);

            recordView.text = PlayerPrefs.GetInt("ScoreLevel").ToString();
        }
        else if (recordView.IsActive())
        {
            recordInfinite = destroyPoints;

            if (PlayerPrefs.GetInt("ScoreInfinite") <= recordInfinite)
                PlayerPrefs.SetInt("ScoreInfinite", recordInfinite);

            recordView.text = PlayerPrefs.GetInt("ScoreInfinite").ToString();
        }
        else if (finalScore.IsActive())
            finalScore.text = destroyPoints.ToString();

        PlayerPrefs.SetInt("Level", level);
    }

    public void DestructionPoints()
    {
        destroyPoints++;
        scoreView.text = destroyPoints.ToString();
    }

    public void UnlockingPoints()
    {
        unlockingPoints++;
        skinsView.text = unlockingPoints.ToString();
    }

    public void CompletedLevel()
    {
        level++;
        levelView.text = level.ToString();
    }
}