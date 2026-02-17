using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int scoreValue = 1; // the amount of score to add when the player enters the trigger, can be set in the Unity editor for flexibility
    private bool hasScored = false; // flag to ensure the score is only incremented once per trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasScored) return; // if the score has already been incremented for this trigger, do not execute the scoring logic again, which could lead to unintended behavior
        if (other.CompareTag("Player"))
        {
           hasScored = true;
           
           GameManager.instance.AddScore(scoreValue); 
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
