using UnityEngine;

public class ButtonClickEffect : MonoBehaviour
{
    public AudioSource effects;
    public AudioClip click;

    public void ClickSound()
    {
        effects.PlayOneShot(click);
    }
}
