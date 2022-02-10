using UnityEngine;

public class SnakeTracker : MonoBehaviour
{
    [SerializeField]
    private float offsetY;

    public Transform Target;

    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.y = Target.position.y + offsetY;
        transform.position = transformPosition;
    }
}