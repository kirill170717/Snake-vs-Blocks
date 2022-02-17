using UnityEngine;

public class BlockDestroyEffect : MonoBehaviour
{
    public AudioSource effects;
    public AudioClip click;

    public void DestroySound()
    {
        effects.PlayOneShot(click);
    }
}