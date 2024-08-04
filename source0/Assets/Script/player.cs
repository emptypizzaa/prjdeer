using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    public GameObject cake; // Assign the cake GameObject in the inspector



    // Method to call when the "ATTAK" or "ATTAK2" buttons are clicked
  /*  public void TakeCake()
    {
        // Check if cake is assigned
        if (cake != null)
        {
            // Move cake towards player by 4 units
           // StartCoroutine(MoveCake());
            cake.transform.position = Vector3.MoveTowards(cake.transform.position, transform.position, 1);
        }
        else
        {
            Debug.LogError("Cake GameObject is not assigned.");
        }
    }
  */
 

    // Method to call when an interaction button is pressed
    public void TakeCake()
    {
        // Check if the cake is assigned
        if (cake != null)
        {
            // Move the cake towards the player
            StartCoroutine(MoveCakeToPlayer());
        }
        else
        {
            Debug.LogError("Cake GameObject is not assigned.");
        }
    }

    private IEnumerator MoveCakeToPlayer()
    {
        float elapsedTime = 0f;
        float duration = 1.5f; // Time in seconds it takes for the cake to move
        Vector3 originalPosition = cake.transform.position;
        Vector3 targetPosition = transform.position + new Vector3(0, 0, -1); // Slight offset to place the cake in front of the player

        while (elapsedTime < duration)
        {
            cake.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cake.transform.position = targetPosition; // Ensure the cake is exactly at the target position
    }


}


