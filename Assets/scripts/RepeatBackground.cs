using UnityEngine;

public class LoopBackground2D : MonoBehaviour
{
    public float speed = 3f;
    public Transform otherBg;

    private SpriteRenderer sr;
    private float width;
    private float halfWidth;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        halfWidth = sr.bounds.extents.x; // = width/2
    }

    void Update()
    {
        // movimento
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // bordo sinistro della camera
        float camLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

        // se questo pezzo è COMPLETAMENTE fuori a sinistra
        if (sr.bounds.max.x < camLeft)
        {
            // mettilo subito a destra dell'altro pezzo
            float otherRight = otherBg.GetComponent<SpriteRenderer>().bounds.max.x;
            transform.position = new Vector3(otherRight + halfWidth, transform.position.y, transform.position.z);
        }
    }
}

