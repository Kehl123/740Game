using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DestroyScript : MonoBehaviour
{
    bool destroyed;
    public Sprite destroyedSprite;
    public SpriteRenderer spriteRenderer;

    public void destroyedEvent()
    {
        spriteRenderer.sprite = destroyedSprite;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
