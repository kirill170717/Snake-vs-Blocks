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

    private bool MusicPlaying
    {
        get { return Data.instance.settings.music; }
        set { Data.instance.settings.music = value; }
    }
    private bool EffectsPlaying
    {
        get { return Data.instance.settings.effects; }
        set { Data.instance.settings.effects = value; }
    }
    private bool VibrationPlaying
    {
        get { return Data.instance.settings.vibration; }
        set { Data.instance.settings.vibration = value; }
    }

    private void Awake()
    {
        instance = this;
        music.isOn = MusicPlaying;
        effects.isOn = EffectsPlaying;
        vibration.isOn = VibrationPlaying;
    }

    private void Update()
    {
        MusicPlaying = music.isOn;
        EffectsPlaying = effects.isOn;
        VibrationPlaying = vibration.isOn;
    }

    public void MuteMusic()
    {
        backgroundMusic.mute = !music.isOn;
    }

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