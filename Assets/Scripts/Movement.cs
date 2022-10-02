using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]float speed = 5f;
    [SerializeField]float jumpHeight = 5f;
    BoxCollider2D boxCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {
        float hControl = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(hControl * speed, rb.velocity.y);
        rb.velocity = movement;
    }
        void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jump = new Vector2(rb.velocity.x, jumpHeight);
            rb.velocity += jump;
        }

    }
}
