using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D catRb;
    public float speed = 1f;
    public float jumpHeight;
    public float horizontalInput;
    public Vector2 moveDirection;
    public Transform translate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector2 (horizontalInput, 0);
        UpAndDown();
    }

    private void FixedUpdate()
    {
        catRb.velocity += moveDirection.normalized * speed;
        //catRb.velocity += jumpDirection.normalized * speed;
    }

    private void UpAndDown()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * jumpHeight);
        }
    }
}
