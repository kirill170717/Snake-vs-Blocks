using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject pause;
    public GameObject gameOver;
    public GameObject skinsMenu;
    public GameObject challengeMenu;
    public GameObject canvas;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!mainMenu || !gameOver)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        canvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
        canvas.SetActive(false);
        pause.SetActive(true);
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        if(pause)
            pause.SetActive(false);
        else
            gameOver.SetActive(false);

        mainMenu.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        canvas.SetActive(false);
        gameOver.SetActive(true);
    }

    public void Restart() => SceneManager.LoadScene(0);
    public void OpenSettings() => settings.SetActive(true);
    public void CloseSettings() => settings.SetActive(false);
}