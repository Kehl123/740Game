using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    Vector3 forward, right;
    Rigidbody rb;
    Animator animator;
    [SerializeField] GameObject head;
    


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3 (0, 90, 0)) * forward;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
            Move();
            //FlipChar();
    }

    void Move()
    {
        float hControl = Input.GetAxis("HorizontalKey");
        float vControl = Input.GetAxis("VerticalKey");
        Vector3 direction = new Vector3(hControl, 0, vControl);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        AnimationCheck(hControl, vControl); 
        FlipChar(hControl);
        
    }

    void AnimationCheck(float hControl, float vControl)
    {
        if (hControl != 0 || vControl != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void FlipChar(float hControl)
    {
        if(hControl < 0)
        {
            transform.localScale = new Vector2(-0.2f, transform.localScale.y);
        }
        else if(hControl > 0)
        {
            transform.localScale = new Vector2(0.2f, transform.localScale.y);
        }
    }
    
}
