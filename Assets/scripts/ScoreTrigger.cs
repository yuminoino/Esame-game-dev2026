using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false; // flag to ensure the score is only incremented once per trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasScored) return; // if the score has already been incremented for this trigger, do not execute the scoring logic again, which could lead to unintended behavior
        if (other.CompareTag("Player"))
        {
           hasScored = true;
           
           GameManager.instance.AddScore(1); // call the AddScore method in the GameManager to update the score display, ensuring that the UI reflects the new score after incrementing
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
