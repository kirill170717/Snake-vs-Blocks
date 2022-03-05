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

    private int ScoreLevel
    {
        get { return Data.instance.player.scoreLevel; }
        set { Data.instance.player.scoreLevel = value; }
    }
    private int ScoreInfinite
    {
        get { return Data.instance.player.scoreInfinite; }
        set { Data.instance.player.scoreInfinite = value; }
    }
    private int RecordLevel
    {
        get { return Data.instance.player.recordLevel; }
        set { Data.instance.player.recordLevel = value; }
    }
    private int RecordInfinite
    {
        get { return Data.instance.player.recordInfinite; }
        set { Data.instance.player.recordInfinite = value; }
    }
    private int UnlockPoints
    {
        get { return Data.instance.player.unlockPoints; }
        set { Data.instance.player.unlockPoints = value; }
    }
    private int Level
    {
        get { return Data.instance.player.completedLevel; }
        set { Data.instance.player.completedLevel = value; }
    }

    private void Awake()
    {
        instance = this;   
    }

    private void Start()
    {
        levelView.text = Level.ToString();
        skinsView.text = UnlockPoints.ToString();
    }

    public void Update()
    {
        if (GameMode.instance.levels.isOn)
        {
            RecordLevel = ScoreLevel;
            if (PlayerPrefs.GetInt("ScoreLevel") <= RecordLevel)
                PlayerPrefs.SetInt("ScoreLevel", RecordLevel);

            recordView.text = PlayerPrefs.GetInt("ScoreLevel").ToString();
            finalScore.text = ScoreLevel.ToString();
        }
        else
        {
            RecordInfinite = ScoreInfinite;
            if (PlayerPrefs.GetInt("ScoreInfinite") <= RecordInfinite)
                PlayerPrefs.SetInt("ScoreInfinite", RecordInfinite);

            recordView.text = PlayerPrefs.GetInt("ScoreInfinite").ToString();
            finalScore.text = ScoreInfinite.ToString();
        }
    }

    public void DestructionPoints()
    {
        if (GameMode.instance.levels.isOn)
        {
            ScoreLevel++;
            scoreView.text = ScoreLevel.ToString();
        }
        else
        {
            ScoreInfinite++;
            scoreView.text = ScoreInfinite.ToString();
        }
    }

    public void UnlockingPoints()
    {
        UnlockPoints++;
        skinsView.text = UnlockPoints.ToString();
    }

    public void CompletedLevel()
    {
        Level++;
        levelView.text = Level.ToString();
        UnlockingPoints();
    }
}