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
    private playerInputController inputController;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (hinput.gamepad.Count > playerNumber)
        {
            inputController = GamePadInputController.CreateGamepadInputController(false, playerNumber);
        }
        else
        {
            inputController = KeyboardInputController.CreateKeyboardInputController(false, this.moveUp, this.moveDown);
        }
        //inputController = GamePadInputController.CreateGamepadInputController(false, playerNumber);
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (inputController.IsMoveUp())
        {
            vel.y = speed;
        }
        else if (inputController.IsMoveDown())
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
}
