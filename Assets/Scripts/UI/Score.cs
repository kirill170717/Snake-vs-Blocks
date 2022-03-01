using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TMP_Text scoreView;
    public TMP_Text skinsView;
    public TMP_Text recordView;
    public TMP_Text finalScore;

    private int destroyPoints;
    private int unlockingPoints;
    private int record;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (recordView.IsActive())
        {
            record = destroyPoints;
            if (PlayerPrefs.GetInt("Score") <= record)
                PlayerPrefs.SetInt("Score", record);
            recordView.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else if (finalScore.IsActive())
            finalScore.text = destroyPoints.ToString();
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
}