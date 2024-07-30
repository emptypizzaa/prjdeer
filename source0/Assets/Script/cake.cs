using System.Collections;
using UnityEngine;

public class cake : MonoBehaviour
{
    public Transform target; // Assign the target in the inspector (pc2)
    public float moveDuration = 1.5f; // Duration of the move towards the target

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not set for cake movement.");
            return;
        }
        StartCoroutine(MoveToTargetRepeatedly());
    }

    private IEnumerator MoveToTargetRepeatedly()
    {
        while (true)
        {
            yield return MoveToTarget(); // Move to the target
            yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds before the next move
        }
    }

    private IEnumerator MoveToTarget()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = target.position;
        float elapsed = 0;

        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition; // Ensure it ends exactly at the target position
    }
}
