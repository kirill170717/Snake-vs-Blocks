using UnityEditor;

[CustomEditor(typeof(ChallengeTypes))]
public class ChallengeTypesEditGUI : Editor
{

    ChallengeTypes challengeTypes;

    private void OnEnable()
    {
        challengeTypes = (ChallengeTypes)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        challengeTypes.type = (ChallengeTypes.Type)EditorGUILayout.EnumPopup("Type", challengeTypes.type);

        switch (challengeTypes.type)
        {
            case ChallengeTypes.Type.DestroyBlocksCount:
                challengeTypes.count = EditorGUILayout.IntField("Count", challengeTypes.count);
                break;
            case ChallengeTypes.Type.SnakeLength:
                challengeTypes.length = EditorGUILayout.IntField("Length", challengeTypes.length);
                break;
            case ChallengeTypes.Type.ScorePoints:
                challengeTypes.score = EditorGUILayout.IntField("Score", challengeTypes.score);
                break;
            case ChallengeTypes.Type.CollectBalls:
                challengeTypes.balls = EditorGUILayout.IntField("Balls", challengeTypes.balls);
                break;
            case ChallengeTypes.Type.Survive:
                challengeTypes.time = EditorGUILayout.IntField("Time", challengeTypes.time);
                break;
            case ChallengeTypes.Type.DestroyBlocksSizeCount:
                challengeTypes.size = EditorGUILayout.IntField("Size", challengeTypes.size);
                challengeTypes.count = EditorGUILayout.IntField("Count", challengeTypes.count);
                break;
        }
        EditorGUILayout.EndVertical();
    }
}