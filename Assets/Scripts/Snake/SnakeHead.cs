using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    public event UnityAction BlockCollided;
    public event UnityAction<int> CircleCollect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            SnakeMovement.instance.block = true;
            if (UiManager.instance.btnStatus == true)
            {
                block.gameObject.SetActive(false);
                UiManager.instance.btnStatus = false;
            }
            else
            {
                BlockCollided?.Invoke();
                block.Fill();
                SoundsManager.instance.EffectsSound(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bonus circle))
            CircleCollect?.Invoke(circle.Collect());
        else if (collision.TryGetComponent(out Finish finish))
            finish.FinishLevel();
    }
}