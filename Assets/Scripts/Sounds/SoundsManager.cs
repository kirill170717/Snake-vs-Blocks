using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    [Header("Toggles")]
    public Toggle music;
    public Toggle effects;
    public Toggle vibration;

    [Header("Audio sources")]
    public AudioSource backgroundMusic;
    public AudioSource effectsSound;

    [Header("Audio clips")]
    public AudioClip[] effectsClips;

    private void Awake()
    {
        instance = this;
        music.isOn = PlayerPrefs.GetInt("Music") != 0;
        effects.isOn = PlayerPrefs.GetInt("Effects") != 0;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("Music", music.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Effects", effects.isOn ? 1 : 0);
    }

    public void MuteMusic() => backgroundMusic.mute = !music.isOn;

    public void EffectsSound(int value)
    {
        if (effects.isOn)
        {
            switch (value)
            {
                case 0:
                    effectsSound.clip = effectsClips[0];
                    break;
                case 1:
                    effectsSound.clip = effectsClips[1];
                    break;
            }
            effectsSound.Play();
        }
    }

    public void Vibration()
    {
        if (vibration.isOn)
            Handheld.Vibrate();
    }
}