using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void FinishLevel()
    {
        SceneManager.LoadScene(0);
    }
}