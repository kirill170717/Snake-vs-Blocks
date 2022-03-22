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
        DrawDefaultInspector();
        serializedObject.Update();

        if(challengeTypes.type == ChallengeTypes.Type.DestroyBlocksSizeCount)
            challengeTypes.size = EditorGUILayout.IntField("Size", challengeTypes.size);

        serializedObject.ApplyModifiedProperties();
    }
}