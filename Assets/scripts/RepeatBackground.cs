using UnityEngine;

public class LoopBackground2D : MonoBehaviour
{
    public float speed = 10f;
 

    private SpriteRenderer sr;
    private float width;
    private float halfWidth;
    public Transform otherBg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        halfWidth = sr.bounds.extents.x; // = width/2
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        // Move left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // sx 
        float camLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

        // if completely out of screen on the left
        if (sr.bounds.max.x < camLeft)
        {
            // put it to the right of the other background
            float otherRight = otherBg.GetComponent<SpriteRenderer>().bounds.max.x;
            transform.position = new Vector3(otherRight + halfWidth, transform.position.y, transform.position.z);
        }
    }
}

