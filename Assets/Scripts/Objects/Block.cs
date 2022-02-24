using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    public int minPriceRange;
    public int maxPriceRange;
    public Color low, medium, high;

    private SpriteRenderer spriteRenderer;
    private int destroyPrice;
    private int filling;

    public int LeftToFill => destroyPrice - filling;

    public event UnityAction<int> FillingUpdated;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //SetColor(snake.length);

        destroyPrice = Random.Range(minPriceRange, maxPriceRange);
        FillingUpdated?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        filling++;
        FillingUpdated?.Invoke(LeftToFill);
        Score.Instance.DestructionPoints();

        if (filling == destroyPrice)
        {
            SoundsManager.Instance.DestroySound();
            Destroy(gameObject);
        }
    }

    //private void SetColor(int length)
    //{
    //    if (destroyPrice > length)
    //        spriteRenderer.color = high;
    //    else if (destroyPrice > length / 2)
    //        spriteRenderer.color = medium;
    //    else
    //        spriteRenderer.color = low;
    //}
}