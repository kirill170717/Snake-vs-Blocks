using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    public int minPriceRange;
    public int maxPriceRange;
    public Color[] colors;

    private SpriteRenderer spriteRenderer;
    private int destroyPrice;
    private int filling;

    public int LeftToFill => destroyPrice - filling;

    public event UnityAction<int> FillingUpdated;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(colors[Random.Range(0, colors.Length)]);

        destroyPrice = Random.Range(minPriceRange, maxPriceRange);
        FillingUpdated?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        filling++;
        FillingUpdated?.Invoke(LeftToFill);

        if (filling == destroyPrice)
        {
            Destroy(gameObject);
        }
    }

    private void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}