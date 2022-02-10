using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform container;
    [SerializeField]
    private int repeatCount;
    [SerializeField]
    private int distanceBetweenFullLine;
    [SerializeField]
    private int distanceBetweenRandomLine;
    [SerializeField]
    private Block block;
    [SerializeField]
    private int blockSpawnChance;

    private SpawnPoint[] blockSpawnPoints;

    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<SpawnPoint>();

        for(int i = 0; i < repeatCount; i++)
        {
            MoveSpawner(distanceBetweenFullLine);
            GenerateFullLine(blockSpawnPoints, block.gameObject);
            MoveSpawner(distanceBetweenRandomLine);
            GenerateRandomElements(blockSpawnPoints, block.gameObject, blockSpawnChance);
        }
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].transform.position, generatedElement);
        }
    }

    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(Random.Range(0, 100) < spawnChance)
            {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generatedElement);
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