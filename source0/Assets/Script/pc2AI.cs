using UnityEngine;

public class pc2AI : MonoBehaviour
{
 
    public Transform targetPosition; // The target position for the AI to move towards
    public float moveSpeed = 2.0f; // Speed at which the AI moves

    private void Update()
    {
        // If the target position is set, move towards it
        if (targetPosition != null)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        // Move towards the target position
        Vector3 direction = (targetPosition.position - transform.position).normalized;
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);
    }

    // Method to be called when the AI interacts with the player or other objects
    public void InteractWithPlayer()
    {
        // Define interaction logic here, e.g., starting a dialogue, giving an item, etc.
        Debug.Log("PC2AI interacts with the player.");
    }


}
