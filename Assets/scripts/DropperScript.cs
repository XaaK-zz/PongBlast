using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperScript : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.T;
    public KeyCode moveDown = KeyCode.G;
    public KeyCode moveLeft = KeyCode.F;
    public KeyCode moveRight = KeyCode.H;
    public KeyCode action = KeyCode.Space;
    public KeyCode shiftLeft = KeyCode.Q;
    public KeyCode shiftRight = KeyCode.E;
    private SpriteRenderer sprite;
    public int playerNumber;
    private playerInputController inputController;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (hinput.gamepad.Count > playerNumber)
        {
            inputController = GamePadInputController.CreateGamepadInputController(true, playerNumber, false);
        }
        else
        {
            inputController = KeyboardInputController.CreateKeyboardInputController(true, this.moveUp, this.moveDown, this.moveLeft, this.moveRight, this.action, this.shiftLeft, this.shiftRight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        if (inputController.IsMoveUp())
        {
            pos.y += this.sprite.bounds.size.y;
            transform.position = pos;
        }
        else if (inputController.IsMoveDown())
        {
            pos.y -= this.sprite.bounds.size.y;
            transform.position = pos;
        }
        else if (inputController.IsMoveLeft())
        {
            pos.x -= this.sprite.bounds.size.x;
            transform.position = pos;
        }
        else if (inputController.IsMoveRight())
        {
            pos.x += this.sprite.bounds.size.x;
            transform.position = pos;
        }

        if (inputController.IsDropAction())
        {
            //Drop block into scene
            Debug.Log("Drop");
        }
    }
}
