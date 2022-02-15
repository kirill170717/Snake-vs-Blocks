using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    public Transform container;
    public int repeatCount;
    public int distanceBetweenFullLine;
    public int distanceBetweenRandomLine;

    [Header("Block")]
    public Block block;
    public int blockSpawnChance;

    [Header("Wall")]
    public Wall wall;
    public int wallSpawnChance;

    [Header("Circle")]
    public Circle circle;
    public int circleSpawnChance;

    private BlockSpawnPoint[] blockSpawnPoints;
    private WallSpawnPoint[] wallSpawnPoints;
    private CircleSpawnPoint[] circleSpawnPoints;
    private GameObject element;

    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        circleSpawnPoints = GetComponentsInChildren<CircleSpawnPoint>();

        for(int i = 0; i < repeatCount; i++)
        {
            MoveSpawner(distanceBetweenFullLine);
            GenerateRandomElements(wallSpawnPoints, wall.gameObject, wallSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle.gameObject, circleSpawnChance);
            GenerateFullLine(blockSpawnPoints, block.gameObject);
            MoveSpawner(distanceBetweenRandomLine);
            GenerateRandomElements(wallSpawnPoints, wall.gameObject, wallSpawnChance);
            GenerateRandomElements(blockSpawnPoints, block.gameObject, blockSpawnChance);
            GenerateRandomElements(circleSpawnPoints, circle.gameObject, circleSpawnChance);
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
        {
            if(Random.Range(0, 100) < spawnChance)
            {
                element = GenerateElement(spawnPoints[i].transform.position, generatedElement);
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