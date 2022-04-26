using UnityEngine;

public class Gums : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}