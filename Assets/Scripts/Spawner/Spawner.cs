using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [Header("General")]
    public Transform container;
    public int distanceBetweenFullLine;
    public int distanceBetweenRandomLine;

    [Header("Level mode")]
    public int repeatCount;

    [Header("Block")]
    public GameObject block;
    public int blockSpawnChance;

    [Header("Wall")]
    public GameObject wall;
    public int wallSpawnChance;

    [Header("Circle")]
    public GameObject circle;
    public int circleSpawnChance;
    
    [Header("Finish")]
    public GameObject finish;

    private BlockSpawnPoint[] blockSpawnPoints;
    private WallSpawnPoint[] wallSpawnPoints;
    private CircleSpawnPoint[] circleSpawnPoints;
    private FinishSpawnPoint finishSpawnPoint;

    private void Awake()
    {
        instance = this;
        blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        circleSpawnPoints = GetComponentsInChildren<CircleSpawnPoint>();
        finishSpawnPoint = GetComponentInChildren<FinishSpawnPoint>();
    }

    public void LevelMode()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            MoveSpawner(distanceBetweenRandomLine);
            GenerateRandomElements(wallSpawnPoints, wall, wallSpawnChance);
            GenerateRandomElements(blockSpawnPoints, block, blockSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, circleSpawnChance);
            MoveSpawner(distanceBetweenFullLine);
            GenerateRandomElements(wallSpawnPoints, wall, wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, circleSpawnChance);
            GenerateFullLine(blockSpawnPoints, block);
        }

        GenerateElement(finishSpawnPoint.transform.position, finish);
    }

    public void InfiniteMode() => StartCoroutine(InfiniteSpawn());

    public IEnumerator InfiniteSpawn()
    {
        while(true)
        {
            MoveSpawner(distanceBetweenRandomLine);
            GenerateRandomElements(wallSpawnPoints, wall, wallSpawnChance);
            GenerateRandomElements(blockSpawnPoints, block, blockSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, circleSpawnChance);
            MoveSpawner(distanceBetweenFullLine);
            GenerateRandomElements(wallSpawnPoints, wall, wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle, circleSpawnChance);
            GenerateFullLine(blockSpawnPoints, block);
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
    {
        for(int i = 0; i < spawnPoints.Length; i++)
            GenerateElement(spawnPoints[i].transform.position, generatedElement);
    }

    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
            if(Random.Range(0, 100) < spawnChance)
                GenerateElement(spawnPoints[i].transform.position, generatedElement);
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement)
    {
        spawnPoint.y -= generatedElement.transform.localScale.y;
        return Instantiate(generatedElement, spawnPoint, Quaternion.identity, container);
    }

    private void MoveSpawner(int distanceY) => transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
}