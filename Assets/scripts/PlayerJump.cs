using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public int maxJumpCount = 2;  // how many times the player can jump before touching the ground again

    private Rigidbody2D playerRb;
    private AudioSource playerAudio;
    private int jumpCount = 0; // current jump count, reset to 0 when player touches the ground, incremented each time player jumps
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) // if the game is over, do not allow the player to jump
            return; // this will prevent the player from jumping after the game is over, which could lead to unintended behavior

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount) // if the space key is pressed and the player has not exceeded the maximum jump count
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // apply an upward force to the player's Rigidbody2D component to make the player jump
            jumpCount++;
            
            playerAudio.PlayOneShot(playerAudio.clip);

            if (animator != null)
                animator.enabled = false; // disable the animator when the player jumps

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           
            jumpCount = 0; // reset jump count when player touches the ground
                if (animator != null)
                    animator.enabled = true; // re-enable the animator when the player touches the ground
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        { 
                
                GameManager.instance.GameOver();
        }
    }
}
