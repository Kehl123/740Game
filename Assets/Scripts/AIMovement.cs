using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float currentSpeed = 4f;
    Vector3 forward, right;
    Rigidbody rb;
    Animator animator;
    public GameObject[] waypoints;
    int currentWaypoint = 0;
    [SerializeField] float waypointAccuracy = 0.5f;
    [SerializeField] float rotationSpeed = 0.4f;
    

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        animator = GetComponent<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        if(waypoints.Length == 0) { return; }
        Vector3 goal = new Vector3(waypoints[currentWaypoint].transform.position.x, transform.position.y, waypoints[currentWaypoint].transform.position.z);
        Vector3 direction = goal - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

        if(direction.magnitude < waypointAccuracy)
        {
            currentWaypoint++;

            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        if(direction.magnitude > 0)
        {
            animator.SetBool("Moving", true);
            Debug.Log("SICK");
        }
        else
        {
            animator.SetBool("Moving", false);
            Debug.Log("NOT SICK");
        }
    }
        
    //void FlipChar(float hControl)
    //{
    //    if (hControl < 0)
    //    {
    //        transform.localScale = new Vector2(1f, transform.localScale.y);
    //    }
    //    else if (hControl > 0)
    //    {
    //        transform.localScale = new Vector2(1f, transform.localScale.y);
    //    }
    //}
}
