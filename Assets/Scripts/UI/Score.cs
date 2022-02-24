using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    public TMP_Text scoreView;
    public TMP_Text skinsView;
    public TMP_Text recordView;

    private int destroyPoints;
    private int unlockingPoints;
    private int record;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }
        Destroy(this.gameObject);
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