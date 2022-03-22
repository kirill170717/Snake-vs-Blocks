using UnityEngine;

public class ChallengeTypes : MonoBehaviour
{
    public enum Type
    {
        DestroyBlocksCount,
        SnakeLength,
        ScorePoints,
        CollectBalls,
        Survive,
        DestroyBlocksSizeCount
    }
    
    public Type type;
    public int value;

    [HideInInspector]
    public int size;

    private string typeName;
    private int typeValue;
    private int typeSize;
    private float time;
    public void CurrentType(ChallengeTypes currentType)
    {
        typeName = currentType.type.ToString();

        if(currentType.type == Type.Survive)
            time = currentType.value;
        else if (currentType.type == Type.DestroyBlocksSizeCount)
        {
            typeValue = currentType.value;
            typeSize = currentType.size;
        } 
        else
            typeValue = currentType.value;
    }

    private void Update()
    {
        if (typeName == Type.DestroyBlocksCount.ToString())
        {

        }
        else if (typeName == Type.SnakeLength.ToString())
        {

        }
        else if (typeName == Type.ScorePoints.ToString())
        {

        }
        else if (typeName == Type.CollectBalls.ToString())
        {

        }
        else if (typeName == Type.Survive.ToString())
        {
            time -= Time.deltaTime;
            //= Mathf.Round(time).ToString();
            if (time == 0)
                UiManager.instance.CompleteChallenge();
        }
        else if(typeName == Type.DestroyBlocksSizeCount.ToString())
        {

        }
    }
}