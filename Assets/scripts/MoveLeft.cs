using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
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
        
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
