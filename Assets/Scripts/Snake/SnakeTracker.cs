using UnityEngine;

public class SnakeTracker : MonoBehaviour
{
    [SerializeField]
    private float setY;

    public Transform Target;

    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.y = Target.position.y + setY;
        transform.position = transformPosition;
    }
}