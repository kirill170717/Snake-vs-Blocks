using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public SpriteRenderer sprite;
    public SkinsDict dict;
    public TMP_Text view;
    public int minSizeRange;
    public int maxSizeRange;

    public int CirclesCollected
    {
        get { return Data.instance.player.circlesCollected; }
        set { Data.instance.player.circlesCollected = value; }
    }

    private int circleSize;

    private void Start()
    {
        circleSize = Random.Range(minSizeRange, maxSizeRange);
        int id = SkinsManager.instance.SnakeSkin;
        int count = dict.skins[id].sprites.Count - 1;
        sprite.sprite = dict.skins[id].sprites[Random.Range(0, count)];
        view.text = circleSize.ToString();
    }

    public int Collect()
    {
        if(Score.instance.typeChallenge == ChallengesTypes.CollectBalls)
            Score.instance.Counter();

        CirclesCollected++;
        Destroy(gameObject);
        return circleSize;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}