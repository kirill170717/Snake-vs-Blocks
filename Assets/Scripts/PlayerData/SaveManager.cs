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

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            Debug.Log("Фокус");
            SaveController.Save(Data.instance);
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Выход");
        SaveController.Save(Data.instance);
    }
}