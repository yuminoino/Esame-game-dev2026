using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x; // get the x coordinate of the left edge of the screen in world space, which will be used to determine when to destroy the obstacle

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
