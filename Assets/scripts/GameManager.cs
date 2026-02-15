using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");
        Time.timeScale = 0; // pause the game
    }
}
