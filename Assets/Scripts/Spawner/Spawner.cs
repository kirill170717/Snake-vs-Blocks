using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [Header("General")]
    public Transform container;
    public GameObject gums;
    public GameObject block;
    public GameObject wall;
    public GameObject circle;
    public GameObject finish;

    [Header("Infifnite mode")]
    public int distanceBetweenFullLine;
    public int distanceBetweenRandomLine;
    public int averageValue;
    public int percentValue;
    public int blockSpawnChance;
    public int wallSpawnChance;
    public int circleSpawnChance;

    [Header("Level mode")]
    public LevelsDict dict;

    private int Level
    {
        get { return Data.instance.player.completedLevel; }
        set { Data.instance.player.completedLevel = value; }
    }

    private BlockSpawnPoint[] blockSpawnPoints;
    private WallSpawnPoint[] wallSpawnPoints;
    private CircleSpawnPoint[] circleSpawnPoints;
    private FinishSpawnPoint finishSpawnPoint;
    private GumsSpawnPoint gumsSpawnPoint;

    private void Awake()
    {
        instance = this;
        blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        circleSpawnPoints = GetComponentsInChildren<CircleSpawnPoint>();
        finishSpawnPoint = GetComponentInChildren<FinishSpawnPoint>();
        gumsSpawnPoint = GetComponentInChildren<GumsSpawnPoint>();
    }

    public void LevelMode()
    {
        for (int i = 0; i < dict.levels[Level].repeatCount; i++)
        {
            GenerateElement(gumsSpawnPoint.transform.position, gums);
            GenerateRandomElements(blockSpawnPoints, block, dict.levels[Level].blockSpawnChance);
            GenerateRandomElements(wallSpawnPoints, wall, dict.levels[Level].wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, dict.levels[Level].circleSpawnChance);
            MoveSpawner(dict.levels[Level].distanceBetweenRandomLine);
            GenerateElement(gumsSpawnPoint.transform.position, gums);
            GenerateFullLine(blockSpawnPoints, block);
            GenerateRandomElements(wallSpawnPoints, wall, dict.levels[Level].wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, dict.levels[Level].circleSpawnChance);
            MoveSpawner(dict.levels[Level].distanceBetweenFullLine);
        }
        GenerateElement(finishSpawnPoint.transform.position, finish);
    }

    public void InfiniteMode()
    {
        StartCoroutine(InfiniteSpawn());
    }

    public IEnumerator InfiniteSpawn()
    {
        while (true)
        {
            GenerateElement(gumsSpawnPoint.transform.position, gums);
            GenerateRandomElements(blockSpawnPoints, block, blockSpawnChance);
            GenerateRandomElements(wallSpawnPoints, wall, wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, circleSpawnChance);
            MoveSpawner(distanceBetweenRandomLine);
            GenerateElement(gumsSpawnPoint.transform.position, gums);
            GenerateFullLine(blockSpawnPoints, block);
            GenerateRandomElements(wallSpawnPoints, wall, wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, circleSpawnChance);
            MoveSpawner(distanceBetweenFullLine);
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 spawnPoint = spawnPoints[i].transform.position;
            spawnPoint.y -= generatedElement.transform.localScale.y;
            Instantiate(generatedElement, spawnPoint, Quaternion.identity, container);
        }
    }

    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                Vector3 spawnPoint = spawnPoints[i].transform.position;
                spawnPoint.y -= generatedElement.transform.localScale.y;
                Instantiate(generatedElement, spawnPoint, Quaternion.identity, container);
            }
        }
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement)
    {
        spawnPoint.y -= generatedElement.transform.localScale.y;
        return Instantiate(generatedElement, spawnPoint, Quaternion.identity, container);
    }

    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }
}