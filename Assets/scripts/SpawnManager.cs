using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // array of obstacle prefabs to spawn
    public float spawnInterval = 2f;     // how often to spawn obstacles (in seconds)

    private Vector3 spawnPos;

    void Start()
    {
        spawnPos = transform.position;

        InvokeRepeating("SpawnRandomObstacle", 1f, spawnInterval);
    }

    void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        Instantiate(obstaclePrefabs[randomIndex],
                    spawnPos,
                    obstaclePrefabs[randomIndex].transform.rotation);
    }
}
