﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    [Header("Canvas")]
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject pause;
    public GameObject gameOver;
    public GameObject skins;
    public GameObject challenge;
    public GameObject game;

    [Header("Camera")]
    public Camera _camera;

    [Header("Language")]
    public Dropdown language;

    private void Awake()
    {
        language.value = PlayerPrefs.GetInt("Language");
        SwitchLanguage(language.value);
        Time.timeScale = 0;

        if (!Instance)
        {
            Instance = this;
            return;
        }
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (game.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (mainMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }

    public void Play()
    {
        _camera.backgroundColor = new Color(Random.value, Random.value, Random.value);
        mainMenu.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
        game.SetActive(false);
        pause.SetActive(true);
    }

    public void PauseOff()
    {
        game.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        if (pause)
            pause.SetActive(false);
        else
            gameOver.SetActive(false);

        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        game.SetActive(false);
        gameOver.SetActive(true);
        SoundsManager.Instance.Vibration();
    }

    public void OpenSkins()
    {
        mainMenu.SetActive(false);
        skins.SetActive(true);
    }

    public void CloseSkins()
    {
        skins.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenChallenge()
    {
        mainMenu.SetActive(false);
        challenge.SetActive(true);
    }

    public void CloseChallenge()
    {
        challenge.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void SwitchLanguage(int value)
    {
        switch (value)
        {
            case 0:
                LocalizationManager.Instance.SetLocalization(SystemLanguage.English);
                break;
            case 1:
                LocalizationManager.Instance.SetLocalization(SystemLanguage.Russian);
                break;
            case 2:
                LocalizationManager.Instance.SetLocalization(SystemLanguage.German);
                break;
            case 3:
                LocalizationManager.Instance.SetLocalization(SystemLanguage.Spanish);
                break;
            case 4:
                LocalizationManager.Instance.SetLocalization(SystemLanguage.French);
                break;
        }
        
        PlayerPrefs.SetInt("Language", value);
    }
}