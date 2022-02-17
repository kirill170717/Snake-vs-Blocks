using UnityEngine;
using UnityEngine.UI;

public class SlidersSettings : MonoBehaviour
{
    public Slider music;
    public Slider effects;

    private void Start()
    {
        music.value = PlayerPrefs.GetFloat("Music");
        effects.value = PlayerPrefs.GetFloat("Effects");
    }

    public void ChangeMusicVolume(float musicVolume)
    {
        PlayerPrefs.SetFloat("Music", musicVolume);
    }

    public void ChangeEffectsVolume(float effectsVolume)
    {
        PlayerPrefs.SetFloat("Effects", effectsVolume);
    }
}