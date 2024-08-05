using System.Collections;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Transform pc1; // Assign the player's transform in the inspector
    public Transform pc2; // Assign the AI's transform in the inspector
    public float moveDistance = 1.0f; // Distance to move per HP cost
    public float moveDuration = 0.5f; // Duration of the move towards the target
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position; // Store the original position of the cake
    }

    // Method to move the cake towards the player's side
    public void MoveTowardsPlayer()
    {
        Vector3 targetPosition = transform.position + Vector3.right * moveDistance;
        StartCoroutine(MoveToPosition(targetPosition));
    }

    // Method to move the cake towards the AI's side
    public void MoveTowardsAI()
    {
        Vector3 targetPosition = transform.position + Vector3.left * moveDistance;
        StartCoroutine(MoveToPosition(targetPosition));
    }

    // Coroutine to move the cake to the specified position
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure it ends exactly at the target position
    }
}
