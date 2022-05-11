using UnityEngine;

public class SnakeTracker : MonoBehaviour
{
    public float offsetY;

    public Transform Target;
    private Vector3 transformPosition;

    private void Start()
    {
        transformPosition = transform.position;
    }

    private void Update()
    {
        transformPosition.y = Target.position.y + offsetY;
        transform.position = transformPosition;
    }
}