using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    public static Block instance;

    [Header("Cracks")]
    public GameObject crack1;
    public GameObject crack2;
    public GameObject crack3;

    [Header("Teeth")]
    public Sprite tooth1;
    public Sprite tooth2;
    public Sprite tooth3;

    [Header("Colors")]
    public Color low;
    public Color downMedium;
    public Color medium;
    public Color upMedium;
    public Color high;

    private SpriteRenderer spriteRenderer;
    private int destroyPrice;
    private int fullPrice;
    private int count;
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
        crack1.SetActive(false);
        crack2.SetActive(false);
        crack3.SetActive(false);
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        fullPrice = destroyPrice;
    }

    private void FixedUpdate()
    {
        count = destroyPrice - filling;
        SetSprite();
        SetColor(SnakeMovement.instance.SnakeLength);
    }

    public void Fill()
    {
        filling++;
        FillingUpdated?.Invoke(LeftToFill);

        if (Score.instance.typeChallenge == ChallengesTypes.NoType || Score.instance.typeChallenge == ChallengesTypes.ScorePoints)
            Score.instance.DestructionPoints();

        if (filling == destroyPrice)
        {
            if (Score.instance.typeChallenge == ChallengesTypes.DestroyBlocksCount)
                Score.instance.Counter();
            else if (Score.instance.typeChallenge == ChallengesTypes.DestroyBlocksSizeCount)
                Score.instance.SizeCounter(filling);

            BrokenBlocks++;
            Destroy(gameObject);
        }
    }

    public void SetSprite()
    {
        if (count > fullPrice * 0.75)
            spriteRenderer.sprite = tooth1;
        else if (count > fullPrice * 0.5)
        {
            spriteRenderer.sprite = tooth2;
            crack1.SetActive(true);
        }
        else if (count > fullPrice * 0.25)
        {
            spriteRenderer.sprite = tooth3;
            crack2.SetActive(true);
        }  
        else if (count < fullPrice * 0.25)
            crack3.SetActive(true);
    }

    public void SetColor(int length)
    {
        if (destroyPrice > length * 0.8)
            spriteRenderer.color = high;
        else if (destroyPrice > length * 0.6 && destroyPrice < length * 0.8)
            spriteRenderer.color = upMedium;
        else if (destroyPrice > length * 0.4 && destroyPrice < length * 0.6)
            spriteRenderer.color = medium;
        else if (destroyPrice > length * 0.2 && destroyPrice < length * 0.4)
            spriteRenderer.color = downMedium;
        else if (destroyPrice < length * 0.2)
            spriteRenderer.color = low;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}