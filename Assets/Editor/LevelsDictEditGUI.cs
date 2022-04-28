using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelsDict))]
public class LevelsDictEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        LevelsDict level = (LevelsDict)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Number of levels", GUILayout.MaxWidth(100));
        level.levelsCount = EditorGUILayout.IntField(level.levelsCount, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            level.LoadingCount(level.levelsCount);
        if (GUILayout.Button("Delete"))
            level.DeletingCount(level.levelsCount);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Value change");

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Levels", GUILayout.MaxWidth(50));
        level.beginKey = EditorGUILayout.IntField(level.beginKey, GUILayout.MaxWidth(50));
        EditorGUILayout.LabelField("to", GUILayout.MaxWidth(15));
        level.endKey = EditorGUILayout.IntField(level.endKey, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Distance between full line", GUILayout.MaxWidth(200));
        level.distanceBetweenFullLine = EditorGUILayout.IntField(level.distanceBetweenFullLine, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Distance between random", GUILayout.MaxWidth(200));
        level.distanceBetweenRandom = EditorGUILayout.IntField(level.distanceBetweenRandom, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Repeat count", GUILayout.MaxWidth(200));
        level.repeatCount = EditorGUILayout.IntField(level.repeatCount, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Average value", GUILayout.MaxWidth(200));
        level.averageValue = EditorGUILayout.IntField(level.averageValue, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Percent value", GUILayout.MaxWidth(200));
        level.percentValue = (int)EditorGUILayout.Slider(level.percentValue, 0, 100);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Block spawn chance", GUILayout.MaxWidth(200));
        level.blockSpawnChance = (int)EditorGUILayout.Slider(level.blockSpawnChance, 0, 100);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Wall spawn chance", GUILayout.MaxWidth(200));
        level.wallSpawnChance = (int)EditorGUILayout.Slider(level.wallSpawnChance, 0, 100);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Circle spawn chance", GUILayout.MaxWidth(200));
        level.circleSpawnChance = (int)EditorGUILayout.Slider(level.circleSpawnChance, 0, 100);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (GUILayout.Button("Change values"))
            level.ChangeValues(level.beginKey, level.endKey, level.distanceBetweenFullLine,
            level.distanceBetweenRandom, level.repeatCount, level.averageValue,
            level.percentValue, level.blockSpawnChance, level.wallSpawnChance, level.circleSpawnChance);

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("levels"), true);
        serializedObject.ApplyModifiedProperties();
    }
}