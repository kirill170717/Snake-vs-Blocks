using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    public event UnityAction BlockCollided;
    public event UnityAction<int> CircleCollect;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            BlockCollided?.Invoke();
            block.Fill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Circle circle))
            CircleCollect?.Invoke(circle.Collect());
        else if (collision.TryGetComponent(out Finish finish))
            finish.FinishLevel();
    }
}