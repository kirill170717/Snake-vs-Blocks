using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public static GameMode instance;

    [Header("Toggles")]
    public Toggle levels;
    public Toggle infinite;

    [Header("Text")]
    public GameObject record;
    public GameObject level;

    private void Awake()
    {
        instance = this;
        levels.isOn = PlayerPrefs.GetInt("Levels") != 0;
        infinite.isOn = PlayerPrefs.GetInt("Infinite") != 0;
    }

    private void Update()
    {
        if (levels.isOn)
        {
            record.SetActive(false);
            level.SetActive(true);
        }
        else
        {
            level.SetActive(false);
            record.SetActive(true);
        }
    }

    public void Mode()
    {
        if (levels.isOn)
        {
            record.SetActive(false);
            level.SetActive(true);
            Spawner.instance.LevelMode();
        }
        else
        {
            level.SetActive(false);
            record.SetActive(true);
            Spawner.instance.InfiniteMode();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Levels", levels.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Infinite", infinite.isOn ? 1 : 0);
    }
}