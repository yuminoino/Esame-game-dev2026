using UnityEngine;

public class LoopBackground2D : MonoBehaviour
{
    public float speed = 10f;
 

    private SpriteRenderer sr; // reference to the SpriteRenderer component of the background, which will be used to get the width of the background sprite for looping purposes
    private float width; // width of the background sprite, calculated from the SpriteRenderer's bounds, which will be used to determine when to loop the background
    private float halfWidth; // half of the width of the background sprite, calculated from the SpriteRenderer's bounds, which will be used to position the background correctly when looping
    public Transform otherBg; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x; // get the width of the background sprite from the SpriteRenderer's bounds, which will be used to determine when to loop the background
        halfWidth = sr.bounds.extents.x; // = width/2 - get half of the width of the background sprite from the SpriteRenderer's bounds, which will be used to position the background correctly when looping
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

        // Get the x coordinate of the left edge of the screen in world space, which will be used to determine when to loop the background
        float camLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

        // if completely out of screen on the left
        if (sr.bounds.max.x < camLeft)
        {
            // put it to the right of the other background
            float otherRight = otherBg.GetComponent<SpriteRenderer>().bounds.max.x; // get the x coordinate of the right edge of the other background sprite from its SpriteRenderer's bounds, which will be used to position this background correctly when looping
            transform.position = new Vector3(otherRight + halfWidth, transform.position.y, transform.position.z);
        }
    }
}

