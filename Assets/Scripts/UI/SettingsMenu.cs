using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settings;

    private void Start()
    {
        settings.SetActive(false);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }
}