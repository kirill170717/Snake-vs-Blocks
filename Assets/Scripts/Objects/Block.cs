using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    public static Block instance;

    public int minPriceRange;
    public int maxPriceRange;
    public Color low, downMedium, medium, upMedium,  high;

    private SpriteRenderer spriteRenderer;
    private int destroyPrice;
    [HideInInspector] public int filling;

    public int LeftToFill => destroyPrice - filling;

    public event UnityAction<int> FillingUpdated;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        destroyPrice = Random.Range(minPriceRange, maxPriceRange);
        FillingUpdated?.Invoke(LeftToFill);
    }

    private void Update()
    {
        SetColor(SnakeMovement.instance.SnakeLength);
    }

    public void Fill()
    {
        filling++;
        FillingUpdated?.Invoke(LeftToFill);

        if(Score.instance.typeChallenge == ChallengesTypes.NoType || Score.instance.typeChallenge == ChallengesTypes.ScorePoints)
            Score.instance.DestructionPoints();

        if (filling == destroyPrice)
        {
            if(Score.instance.typeChallenge == ChallengesTypes.DestroyBlocksCount)
                Score.instance.Counter();
            else if(Score.instance.typeChallenge == ChallengesTypes.DestroyBlocksSizeCount)
                Score.instance.SizeCounter(filling);

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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}