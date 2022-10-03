using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    int fire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpFire()
    {
        fire = fire + 1;
        Debug.Log(fire); //How do i add text here so its like Fire = varnumber
    }
}
