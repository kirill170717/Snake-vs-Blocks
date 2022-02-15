using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SettingsMenu settingsMenu;

    private void Start()
    {
        settingsMenu = GetComponent<SettingsMenu>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settingsMenu.OpenSettings();
    }
}