using UnityEngine;

public class MoveAndRepeatBackground : MonoBehaviour
{
    public float speed = 3f;

    private float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        // Muove a sinistra
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

// Quando è uscito a sinistra, lo rimette in coda (serve che ci siano 2 bg affiancati)
