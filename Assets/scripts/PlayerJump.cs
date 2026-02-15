using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public int maxJumpCount = 2;  // how many times the player can jump before touching the ground again

    private Rigidbody2D playerRb;
    private AudioSource playerAudio;
    private int jumpCount = 0;
    private bool isOnGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            isOnGround = false;
            playerAudio.PlayOneShot(playerAudio.clip);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0; // reset jump count when player touches the ground
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        { 
                isOnGround = false;
                GameManager.instance.GameOver();
        }
    }
}
