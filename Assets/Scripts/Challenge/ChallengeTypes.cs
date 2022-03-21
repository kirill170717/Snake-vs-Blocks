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
    
    [SerializeReference]
    public Type type;

    public int count;
    public int length;
    public int score;
    public int balls;
    public int time;
    public int size;

    public void CurrentType(ChallengeTypes currentType)
    {
        switch (currentType.type)
        {
            case Type.DestroyBlocksCount:
                
                break;
            case Type.SnakeLength:

                break;
            case Type.ScorePoints:

                break;
            case Type.CollectBalls:

                break;
            case Type.Survive:

                break;
            case Type.DestroyBlocksSizeCount:

                break;
        }
    }
}