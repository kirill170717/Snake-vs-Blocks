using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    public static Block instance;

    //public Color low, downMedium, medium, upMedium,  high;

    //private SpriteRenderer spriteRenderer;
    private int destroyPrice;
    [HideInInspector] public int filling;

    public int LeftToFill => destroyPrice - filling;

    public event UnityAction<int> FillingUpdated;

    public int BrokenBlocks
    {
        get { return Data.instance.player.brokenBlocks; }
        set { Data.instance.player.brokenBlocks = value; }
    }

    public LevelsDict dict;

    private int Level
    {
        get { return Data.instance.player.completedLevel; }
        set { Data.instance.player.completedLevel = value; }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        int min;
        int max;

        if (GameMode.instance.levels.isOn)
        {
            min = dict.levels[Level].averageValue - (dict.levels[Level].averageValue * dict.levels[Level].percentValue / 100);
            max = dict.levels[Level].averageValue + (dict.levels[Level].averageValue * dict.levels[Level].percentValue / 100);
        }
        else
        {
            min = Spawner.instance.averageValue - (Spawner.instance.averageValue * Spawner.instance.percentValue / 100);
            max = Spawner.instance.averageValue + (Spawner.instance.averageValue * Spawner.instance.percentValue / 100);
        }

        destroyPrice = Random.Range(min, max);
        FillingUpdated?.Invoke(LeftToFill);
    }

    //private void Update()
    //{
    //    SetColor(SnakeMovement.instance.SnakeLength);
    //}

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

            BrokenBlocks++;
            Destroy(gameObject);
        }
    }

    //public void SetColor(int length)
    //{
    //    if (destroyPrice > length)
    //        spriteRenderer.color = high;
    //    else if (destroyPrice > length * 0.75)
    //        spriteRenderer.color = upMedium;
    //    else if (destroyPrice > length * 0.5)
    //        spriteRenderer.color = medium;
    //    else if(destroyPrice > length * 0.25)
    //        spriteRenderer.color = downMedium;
    //    else
    //        spriteRenderer.color = low;
    //}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}