using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    [Header("Toggles")]
    public Toggle levels;
    public Toggle infinite;

    [Header("Mode")]
    public GameObject modeLevels;
    public GameObject modeInfinite;

    [Header("Text")]
    public GameObject record;
    public GameObject level;

    private void Awake()
    {
        levels.isOn = PlayerPrefs.GetInt("Levels") != 0;
        infinite.isOn = PlayerPrefs.GetInt("Infinite") != 0;
    }

    void Update()
    {
        if (levels.isOn)
        {
            modeInfinite.SetActive(false);
            record.SetActive(false);
            level.SetActive(true);
            modeLevels.SetActive(true);
        }
        else
        {
            modeLevels.SetActive(false);
            level.SetActive(false);
            record.SetActive(true);
            modeInfinite.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Levels", levels.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Infinite", infinite.isOn ? 1 : 0);
    }
}