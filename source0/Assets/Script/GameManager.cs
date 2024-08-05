using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player pc1; // Assign in inspector
    public Cake cake; // Assign in inspector (Note: Class name should be capitalized if it's a custom class)
    public PC2AI pc2;  // Assign in inspector
    public float moveDuration = 1.5f; // Duration for cake movement in seconds

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        // Initialize the cake's original position
       // originalPosition = cake.transform.position;
    }

    void Update()
    {
        // The Update method should handle input and game logic rather than moving the cake
        // Removed the dtime-based movement logic here

        // Example: Handle player and AI inputs
        // Assuming a method that gets called when a player or AI decides to move the cake
    }
   
}
