using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton instance of the GameManager, allows other scripts to access it easily
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
    // Awake is called when the script instance is being loaded, before any Start functions are called. This is where we set up the singleton instance of the GameManager.
    void Awake()
    {
        instance = this; // set the singleton instance to this instance of the GameManager, allowing other scripts to access it through GameManager.instance
    }
    public void GameOver()
    {
        if (isGameOver) return; // if the game is already over, do not execute the game over logic again, which could lead to unintended behavior

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
