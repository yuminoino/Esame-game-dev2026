using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;

    public AudioSource backgroundMusic;

    public GameObject particles;
    public GameObject player;

    public GameObject gameOverImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     isGameOver = false;
        if (gameOverImage != null) gameOverImage.SetActive(false);

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
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("GAME OVER");

        if (backgroundMusic != null)

         backgroundMusic.Stop();
        
        if (particles != null)
         particles.SetActive(true);

         if (player != null)
          player.SetActive(false);

         if (gameOverImage != null)
          gameOverImage.SetActive(true);
    }
}
