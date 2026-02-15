using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;

    public AudioSource backgroundMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

    }
}
