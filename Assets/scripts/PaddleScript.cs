using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
     
        
        
    }

    // Update is called once per frame
    void Update()
    {

        string[] names = Input.GetJoystickNames();
        if (names.Length == 0)
        {
            Debug.Log("No controllers");
        }

        var vel = rb2d.velocity;
        if (this.IsMoveUp())
        {
            vel.y = speed;
        }
        else if (this.IsMoveDown())
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }

    public bool IsMoveUp()
    {
        if (hinput.gamepad.Count <= playerNumber)
        {
            //no gamepad - use keyboard
            if (Input.GetKey(moveUp))
            {
                return true;
            }
        }
        else
        {
            if (hinput.gamepad[playerNumber].leftStick.up.pressed)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsMoveDown()
    {
        if (hinput.gamepad.Count <= playerNumber)
        {
            //no gamepad - use keyboard
            if (Input.GetKey(moveDown))
            {
                return true;
            }
        }
        else
        {
            if (hinput.gamepad[playerNumber].leftStick.down.pressed)
            {
                return true;
            }
        }

        return false;
    }
}
