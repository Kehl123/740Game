using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bench : MonoBehaviour
{
    
        
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Hello();
        }
    }

    void Hello()
    {
        foreach(Transform t in transform)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(transform.forward * 2, ForceMode.Impulse);
        }
    }
}
