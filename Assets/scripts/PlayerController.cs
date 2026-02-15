using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 15f;
    public int maxJumpCount = 2;  // how many jumps the player can do before touching the ground again

    private Rigidbody2D playerRb;
    private AudioSource playerAudio;
    private int jumpCount = 0;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            playerAudio.PlayOneShot(playerAudio.clip);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            jumpCount = 0; // reset jump count when player touches the ground
        }
    }
}
