using UnityEngine;


public class MainMenuSounds : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource effectsSource;

    private void Update()
    {
        musicSource.volume = PlayerPrefs.GetFloat("Music");
        effectsSource.volume = PlayerPrefs.GetFloat("Effects");
    }
}