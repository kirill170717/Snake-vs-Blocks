using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    public event UnityAction blockCollided;
    public event UnityAction<int> circleCollect;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Block block))
        {
            blockCollided?.Invoke();
            block.Fill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Circle circle))
        {
            circleCollect?.Invoke(circle.Collect());
        }
    }
}