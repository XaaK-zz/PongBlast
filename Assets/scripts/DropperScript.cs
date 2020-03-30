using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperScript : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.T;
    public KeyCode moveDown = KeyCode.G;
    private SpriteRenderer sprite;
    private bool keyUp = true;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        if (keyUp)
        {
            if (Input.GetKey(moveUp))
            {
                pos.y += this.sprite.bounds.size.y;
                transform.position = pos;
                this.keyUp = false;
            }
            else if (Input.GetKey(moveDown))
            {
                pos.y -= this.sprite.bounds.size.y;
                transform.position = pos;
                this.keyUp = false;
            }
        }
        else
        {
            if(!Input.GetKey(moveUp) && !Input.GetKey(moveDown))
            {
                this.keyUp = true;
            }
        }
    }
}
