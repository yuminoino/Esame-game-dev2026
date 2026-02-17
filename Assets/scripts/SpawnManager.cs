using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] weakEnemyPrefabs; // array of weak enemy prefabs to choose from when spawning weak enemies, can be set in the Unity editor for flexibility
    public GameObject strongEnemyPrefab; // prefab for the strong enemy, can be set in the Unity editor for flexibility

    public float spawnInterval = 2f;
    public float startDelay = 1f;
    public float fasterSpawnInterval = 1.3f;

    public int onlyWeakUntil = 10;
    public int speedUpAfter = 20;
    public int strongChance = 3;
    public float strongMusicPitch = 1.5f;

    private Vector3 spawnPos;
    private int spawnedCount = 0; // keeps track of how many enemies have been spawned, used to determine when to start spawning strong enemies and when to speed up the spawn rate
    private bool strongSpawnedOnce = false; // flag to track if a strong enemy has been spawned at least once, used to determine when to increase the music pitch


    void Start()
    {
        spawnPos = transform.position; // set the spawn position to the position of the SpawnManager object in the scene, which can be adjusted in the Unity editor by moving the SpawnManager object to the desired spawn location
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval); // start invoking the SpawnEnemy method repeatedly after a delay of startDelay seconds, and then every spawnInterval seconds thereafter
    }

    void SpawnEnemy()
    {
        if (GameManager.instance.isGameOver)
            return;

        spawnedCount++; // increment the count of spawned enemies each time this method is called, which will be used to determine when to start spawning strong enemies and when to speed up the spawn rate

        GameObject prefabToSpawn; // variable to hold the prefab that will be spawned, determined based on the number of enemies spawned so far and the random chance for spawning strong enemies

        // First only spawn weak enemies, then start spawning strong ones with a certain chance
        if (spawnedCount <= onlyWeakUntil) // if the number of spawned enemies is less than or equal to the threshold for only spawning weak enemies, then we will only spawn weak enemies
        {
            prefabToSpawn = GetRandomWeak();
        }
        else
        {
            bool spawnStrong = Random.Range(0, strongChance) == 0; // determine whether to spawn a strong enemy based on a random chance, where strongChance is the denominator of the probability (e.g., if strongChance is 3, there is a 1 in 3 chance to spawn a strong enemy)

            if (spawnStrong)
            {
                prefabToSpawn = strongEnemyPrefab;

                // First time we spawn a strong enemy, increase the music pitch
                if (!strongSpawnedOnce)
                {
                    strongSpawnedOnce = true;

                    if (GameManager.instance.backgroundMusic != null)
                        GameManager.instance.backgroundMusic.pitch = strongMusicPitch;
                }
            }
            else
            {
                prefabToSpawn = GetRandomWeak(); // if we are not spawning a strong enemy, then we will spawn a random weak enemy
            }
        }
        // Spawn the chosen enemy prefab at the spawn position with the prefab's default rotation
        Instantiate(prefabToSpawn, spawnPos, prefabToSpawn.transform.rotation); // after spawning the enemy, check if we have reached the threshold for speeding up the spawn rate, and if so, cancel the current repeating invocation of SpawnEnemy and start a new one with the faster spawn interval

        // from a certain point, speed up the spawn rate
        if (spawnedCount == speedUpAfter)
        {
            CancelInvoke(); // cancel the current repeating invocation of SpawnEnemy, which is currently using the original spawn interval
            InvokeRepeating("SpawnEnemy", 0f, fasterSpawnInterval); // start a new repeating invocation of SpawnEnemy with no delay and the faster spawn interval, which will increase the spawn rate of enemies after we have spawned a certain number of them
        }
    }

    GameObject GetRandomWeak()
    {
        if (weakEnemyPrefabs == null || weakEnemyPrefabs.Length == 0) // if there are no weak enemy prefabs assigned in the Unity editor, return null to avoid errors when trying to spawn a weak enemy
            return null;

        int index = Random.Range(0, weakEnemyPrefabs.Length); // get a random index to select a weak enemy prefab from the array of weak enemy prefabs, which allows for variety in the types of weak enemies that are spawned
        return weakEnemyPrefabs[index]; // return the randomly selected weak enemy prefab, which will be used to spawn a weak enemy in the SpawnEnemy method
    }
}
