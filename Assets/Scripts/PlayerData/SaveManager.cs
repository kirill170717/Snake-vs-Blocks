using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        Data.instance = SaveController.Load<Data>();
        SceneManager.LoadScene("Game");
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            SaveController.Save(Data.instance);
    }
}