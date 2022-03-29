using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public static RestartGame instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void Restart()
    {
        StartCoroutine(RestartLevel());
    }

    public IEnumerator RestartLevel()
    {
        SceneManager.LoadScene("Game");
        yield return null;
        UiManager.instance.Play(ChallengesTypes.NoType);
    }
}