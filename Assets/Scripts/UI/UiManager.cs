using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [Header("Canvas")]
    public GameObject game;
    public GameObject pause;
    public GameObject gameOver;
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject skins;
    public GameObject buySkinPoints;
    public GameObject challenge;
    public GameObject selectedChallenge;
    public GameObject challengeComplete;
    public GameObject challengeFailed;
    public GameObject profile;
    public GameObject registration;
    public GameObject authentification;

    [Header("Buttons")]
    public Button playGame;
    public GameObject revive;
    public GameObject getLife;

    [Header("Camera")]
    public Camera _camera;

    private SystemLanguage Language
    {
        get { return Data.instance.settings.language; }
        set { Data.instance.settings.language = value; }
    }

    [Header("Ads")]
    public float persentShowAds;

    private float adsPersent;

    [HideInInspector] public bool btnStatus = false;

    private void Awake()
    {
        instance = this;

        LocalizationManager.instance.SetLocalization(Language);
        playGame.onClick.AddListener(() => Play(ChallengesTypes.NoType));
        Time.timeScale = 0;

        game.SetActive(false);
        settings.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
        skins.SetActive(false);
        buySkinPoints.SetActive(false);
        challenge.SetActive(false);
        selectedChallenge.SetActive(false);
        challengeComplete.SetActive(false);
        challengeFailed.SetActive(false);
        profile.SetActive(false);
        registration.SetActive(false);
        authentification.SetActive(false);
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

        if (Score.instance.Life == 0)
            revive.SetActive(false);
        else
            revive.SetActive(true);
    }

    public void Play(ChallengesTypes type)
    {
        _camera.backgroundColor = new Color(Random.value, Random.value, Random.value);
        GameMode.instance.Mode(type);

        if (type == ChallengesTypes.NoType)
            mainMenu.SetActive(false);
        else
        {
            challenge.SetActive(false);
            selectedChallenge.SetActive(false);
        }

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
        SnakeMovement.instance.SnakeLength = 5;
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Score.instance.Death();
        SoundsManager.instance.Vibration();
        game.SetActive(false);
        gameOver.SetActive(true);
        Score.instance.UnlockingPoints();

        adsPersent = Random.Range(0f, 1f);

        if (adsPersent < persentShowAds)
            InterstitialAds.instance.ShowAd();
    }

    public void Revive()
    {
        btnStatus = true;
        SnakeMovement.instance.ReviveSnake(5);
        gameOver.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SnakeMovement.instance.SnakeLength = 5;
        RestartGame.instance.Restart();
    }

    public void Finish()
    {
        Score.instance.CompletedLevel();

        adsPersent = Random.Range(0f, 1f);

        if (adsPersent < persentShowAds)
            InterstitialAds.instance.ShowAd();

        SceneManager.LoadScene("Game");
    }

    public void SwitchLanguage()
    {
        if (Language == SystemLanguage.English)
        {
            LocalizationManager.instance.SetLocalization(SystemLanguage.Russian);
            Language = SystemLanguage.Russian;
        }
        else
        {
            LocalizationManager.instance.SetLocalization(SystemLanguage.English);
            Language = SystemLanguage.English;
        }
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

    public void OpenBuySkinPoints()
    {
        buySkinPoints.SetActive(true);
    }
    
    public void CloseBuySkinPoints()
    {
        buySkinPoints.SetActive(false);
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
    public void OpenChallengeMenu()
    {
        selectedChallenge.SetActive(true);
    }

    public void CloseChallengeMenu()
    {
        selectedChallenge.SetActive(false);
    }
    public void CompleteChallenge(int number)
    {
        challengeComplete.SetActive(true);
        ChallengesManager.instance.ChallengeComplete(number);
        Time.timeScale = 0;
    }
    public void FailedChallenge()
    {
        Time.timeScale = 0;
        SoundsManager.instance.Vibration();
        game.SetActive(false);
        challengeFailed.SetActive(true);

        adsPersent = Random.Range(0f, 1f);

        if (adsPersent < persentShowAds)
            InterstitialAds.instance.ShowAd();
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void OpenAuth()
    {
        authentification.SetActive(true);
    }
    
    public void CloseAuth()
    {
        authentification.SetActive(false);
    }
    
    public void OpenReg()
    {
        authentification.SetActive(false);
        registration.SetActive(true);
    }

    public void CloseReg()
    {
        registration.SetActive(false);
        authentification.SetActive(true);
    }
    public void OpenProfile()
    {
        profile.SetActive(true);
    }

    public void CloseProfile()
    {
        profile.SetActive(false);
    }
}