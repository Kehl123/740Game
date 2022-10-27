using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabScript : MonoBehaviour
{
    [SerializeField] Transform raycastPoint;
    [SerializeField] float raycastLegnth = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }
        public void Stab()
    {
        RaycastHit hit;
        if(Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, raycastLegnth))
        {
            DestroyScript destroyScriptOnObject = hit.collider.gameObject.GetComponent<DestroyScript>();
            if(destroyScriptOnObject != null)
            {
                destroyScriptOnObject.destroyedEvent();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
