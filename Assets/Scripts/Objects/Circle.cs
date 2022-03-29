using TMPro;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public TMP_Text view;
    public int minSizeRange;
    public int maxSizeRange;

    private int circleSize;

    private void Start()
    {
        circleSize = Random.Range(minSizeRange, maxSizeRange);
        view.text = circleSize.ToString();
    }

    public int Collect()
    {
        if(Score.instance.typeChallenge == ChallengesTypes.CollectBalls)
            Score.instance.Counter();

        Destroy(gameObject);
        return circleSize;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}