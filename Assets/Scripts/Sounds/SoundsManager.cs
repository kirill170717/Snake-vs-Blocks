using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance { get; private set; }

    [Header("Toggles")]
    public Toggle music;
    public Toggle effects;
    public Toggle vibration;

    [Header("Sounds")]
    public AudioSource backgroundMusic;
    public AudioSource buttonEffects;
    public AudioSource blockEffects;

    private void Awake()
    {
        music.isOn = PlayerPrefs.GetInt("Music") != 0;
        effects.isOn = PlayerPrefs.GetInt("Effects") != 0;

        if (!Instance)
        {
            Instance = this;
            return;
        }
        else
            Destroy(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Music", music.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Effects", effects.isOn ? 1 : 0);
    }

    public void MuteMusic()
    {
        backgroundMusic.mute = !music.isOn;
    }

    public void ClickSound()
    {
        if(effects.isOn)
            buttonEffects.Play();
    }

    public void DestroySound()
    {
        if (effects.isOn)
            blockEffects.Play();
    }

    public void Vibration()
    {
        if (vibration.isOn)
            Handheld.Vibrate();
    }
}