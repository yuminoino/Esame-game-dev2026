using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // array of obstacle prefabs to spawn
    public float spawnInterval = 2f;     // how often to spawn obstacles (in seconds)
    public float startDelay = 1f;
    private Vector3 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPos = transform.position; 

        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomObstacle()
    {
        if (GameManager.instance.isGameOver)
            return; // if the game is over, do not spawn new obstacles, which could lead to unintended behavior

        int randomIndex = Random.Range(0, obstaclePrefabs.Length); // get a random index to select a random obstacle prefab from the array

        Instantiate(obstaclePrefabs[randomIndex], // instantiate the selected obstacle prefab at the spawn position with its default rotation
                    spawnPos,
                    obstaclePrefabs[randomIndex].transform.rotation);
    }
}
