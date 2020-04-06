using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperScript : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.T;
    public KeyCode moveDown = KeyCode.G;
    private SpriteRenderer sprite;
    private bool keyUp = true;
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        if (this.IsMoveUp())
        {
            pos.y += this.sprite.bounds.size.y;
            transform.position = pos;
            this.keyUp = false;
        }
        else if (this.IsMoveDown())
        {
            pos.y -= this.sprite.bounds.size.y;
            transform.position = pos;
            this.keyUp = false;
        }
    }

    public bool IsMoveUp()
    {
        if (hinput.gamepad.Count == 0)
        {
            //no gamepad - use keyboard
            if (Input.GetKey(moveUp) && this.keyUp)
            {
                this.keyUp = false;
                return true;
            }
            else
            {
                this.keyUp = true;
            }
        }
        else
        {
            if (hinput.gamepad[playerNumber].rightStick.up.justPressed)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsMoveDown()
    {
        if (hinput.gamepad.Count == 0)
        {
            //no gamepad - use keyboard
            if (Input.GetKey(moveDown) && this.keyUp)
            {
                this.keyUp = false;
                return true;
            }
            else
            {
                this.keyUp = true;
            }
        }
        else
        {
            if (hinput.gamepad[playerNumber].rightStick.down.justPressed)
            {
                return true;
            }
        }

        return false;
    }
}
