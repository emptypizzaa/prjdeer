using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    public GameObject cake; // Assign the cake GameObject in the inspector

    // Method to call when the "ATTAK" or "ATTAK2" buttons are clicked
    public void TakeCake()
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
}


