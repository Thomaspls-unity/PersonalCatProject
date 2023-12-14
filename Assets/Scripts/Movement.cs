using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D catRb;
    public float speed = 1f;
    public float horizontalInput;
    public Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetKeyDown(KeyCode.W);
        
        horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector2 (horizontalInput, 0);
    }

    private void FixedUpdate()
    {
        catRb.velocity += moveDirection.normalized * speed;
    }
}
