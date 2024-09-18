using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float moveDistance = 1f; // Distance Pac-Man moves per key press

    Item[] items;

    public Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right; // Initial Direction to the right.  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GridCell"))
        {
            Cell cellComponent = collision.gameObject.GetComponent<Cell>();
            if (cellComponent != null)
            {
                cellComponent.ActivateCell();
            }
        }
    }


    void Move()
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveDistance * Time.fixedDeltaTime));
    }

    private void MoveDirection(Vector2 dir)
    {
        Vector2 newPosition = (Vector2)this.transform.position + dir * moveDistance;
        transform.position = newPosition;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        /*      if (x != 0 || y != 0)
      {        movement2D.MoveDirection = new Vector3(x, y, 0);}*/


        Vector2 newPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //newPosition += Vector2.up * moveDistance;
            MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //movement2D.MoveDirection = Vector3.down;

            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //movement2D.MoveDirection = Vector3.left;
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }



    }
    public void MoveUp()
    {
        MoveDirection(Vector2.up);
    }

    public void MoveDown()
    {
        MoveDirection(Vector2.down);
    }

    public void MoveLeft()
    {
        MoveDirection(Vector2.left);
    }

    public void MoveRight()
    {
        MoveDirection(Vector2.right);
    }

}
