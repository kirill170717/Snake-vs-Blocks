using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private void Awake()
    {
        Data.instance = SaveController.Load<Data>();

        if (Data.instance == null)
            Data.instance = new Data();

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Game");
    }

    private bool quit;

    private void OnApplicationFocus(bool focus)
    {
        quit = focus;
        if (!focus)
            SaveController.Save(Data.instance);
    }

    private void OnApplicationQuit()
    {
        if (quit)
            SaveController.Save(Data.instance);
    }
}