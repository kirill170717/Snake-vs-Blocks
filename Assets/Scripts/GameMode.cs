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
        PlayerPrefs.SetInt("Levels", levels.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Infinite", infinite.isOn ? 1 : 0);

        if (levels.isOn)
            level.SetActive(true);
        else
        {
            level.SetActive(false);
            record.SetActive(true);
        }
    }

    public void Mode()
    {
        if (levels.isOn)
            Spawner.instance.LevelMode();
        else
            Spawner.instance.InfiniteMode();
    }
}