using TMPro;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text view;
    [SerializeField]
    private int minSizeRange;
    [SerializeField]
    private int maxSizeRange;

    private int circleSize;

    private void Start()
    {
        circleSize = Random.Range(minSizeRange, maxSizeRange );
        view.text = circleSize.ToString();
    }

    public int Collect()
    {
        Destroy(gameObject);
        return circleSize;
    }
}