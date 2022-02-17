using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource effectsSource;

    private void Awake()
    {
        musicSource.volume = PlayerPrefs.GetFloat("Music");
        effectsSource.volume = PlayerPrefs.GetFloat("Effects");
    }
}