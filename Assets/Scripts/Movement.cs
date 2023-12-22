using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D catRb;
    public Transform translate;
    public Vector2 moveDirection;

    public float speed;
    //public float jumpHeight;

    public float jumpForce;
    public float gravityModifier;
    public float horizontalInput;

    public int sideBoundary = 9;
    public int gameOverBoundary = -5;

    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        catRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftAndRight();
        Boundaries();
    }

    private void FixedUpdate()
    {
        //catRb.velocity += moveDirection.normalized * speed;
        //catRb.velocity += jumpDirection.normalized * speed;
        UpAndDown();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void UpAndDown() //I want to make W jump only when on the ground and S to go down through the intangible floor
    {
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            catRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //transform.Translate(Vector2.up * Time.deltaTime * jumpHeight);

            isOnGround = false;
        }
    }

    private void LeftAndRight()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        moveDirection = new Vector2(horizontalInput, 0).normalized;

        Vector2 movement = moveDirection * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void Boundaries() //Check the player's position and reset it so that it doesn't move off the side
        //Or have the player object removed and Game Over called
    {
        if (transform.position.x > sideBoundary)
        {
            transform.position = new Vector2(sideBoundary, transform.position.y);
        }

        if (transform.position.x < -sideBoundary)
        {
            transform.position = new Vector2(-sideBoundary, transform.position.y);
        }

        if (transform.position.y < gameOverBoundary)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}