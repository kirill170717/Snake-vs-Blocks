using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    public int minPriceRange;
    public int maxPriceRange;
    public Color low, downMedium, medium, upMedium,  high;

    private SpriteRenderer spriteRenderer;
    private int destroyPrice;
    private int filling;

    public int LeftToFill => destroyPrice - filling;

    public event UnityAction<int> FillingUpdated;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        destroyPrice = Random.Range(minPriceRange, maxPriceRange);
        FillingUpdated?.Invoke(LeftToFill);
    }

    private void FixedUpdate() => SetColor(SnakeMovement.instance.length);

    public void Fill()
    {
        filling++;
        FillingUpdated?.Invoke(LeftToFill);
        Score.instance.DestructionPoints();

        if (filling == destroyPrice)
        {
            SoundsManager.instance.DestroySound();
            Destroy(gameObject);
        }
    }

    public void SetColor(int length)
    {
        if (destroyPrice > length)
            spriteRenderer.color = high;
        else if (destroyPrice > length * 0.75)
            spriteRenderer.color = upMedium;
        else if (destroyPrice > length * 0.5)
            spriteRenderer.color = medium;
        else if(destroyPrice > length * 0.25)
            spriteRenderer.color = downMedium;
        else
            spriteRenderer.color = low;
    }

    private void OnBecameInvisible() => Destroy(gameObject);
}