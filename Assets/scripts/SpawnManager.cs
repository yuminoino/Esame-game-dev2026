using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] weakEnemyPrefabs;
    public GameObject strongEnemyPrefab;

    public float spawnInterval = 2f;
    public float startDelay = 1f;
    public float fasterSpawnInterval = 1.3f;

    public int onlyWeakUntil = 10;
    public int speedUpAfter = 20;
    public int strongChance = 3;
    public float strongMusicPitch = 1.5f;

    private Vector3 spawnPos;
    private int spawnedCount = 0;
    private bool strongSpawnedOnce = false;


    void Start()
    {
        spawnPos = transform.position;
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (GameManager.instance.isGameOver)
            return;

        spawnedCount++;

        GameObject prefabToSpawn;

        // First only spawn weak enemies, then start spawning strong ones with a certain chance
        if (spawnedCount <= onlyWeakUntil)
        {
            prefabToSpawn = GetRandomWeak();
        }
        else
        {
            bool spawnStrong = Random.Range(0, strongChance) == 0;

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
                prefabToSpawn = GetRandomWeak();
            }
        }

        Instantiate(prefabToSpawn, spawnPos, prefabToSpawn.transform.rotation);

        // from a certain point, speed up the spawn rate
        if (spawnedCount == speedUpAfter)
        {
            CancelInvoke();
            InvokeRepeating("SpawnEnemy", 0f, fasterSpawnInterval);
        }
    }

    GameObject GetRandomWeak()
    {
        if (weakEnemyPrefabs == null || weakEnemyPrefabs.Length == 0)
            return null;

        int index = Random.Range(0, weakEnemyPrefabs.Length);
        return weakEnemyPrefabs[index];
    }
}
