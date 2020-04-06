using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeyboardInputController : playerInputController
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;

    protected bool[] keyUp = { true, true, true, true };
    private enum moveDirection { Up, Down, Left, Right};

    private KeyboardInputController(KeyCode _moveUp, KeyCode _moveDown, KeyCode _moveLeft, KeyCode _moveRight)
    {
        this.moveUp = _moveUp;
        this.moveDown = _moveDown;
        this.moveLeft = _moveLeft;
        this.moveRight = _moveRight;
    }

    static public KeyboardInputController CreateKeyboardInputController(bool _singlePress, KeyCode _moveUp, KeyCode _moveDown, KeyCode _moveLeft, KeyCode _moveRight)
    {
        KeyboardInputController controller = new KeyboardInputController(_moveUp, _moveDown, _moveLeft, _moveRight);
        controller.SinglePress = _singlePress;
        return controller;
    }

    private KeyCode enumToKeyCode(moveDirection direction)
    {
        if (direction == moveDirection.Up)
        {
            return this.moveUp;
        }
        else if(direction == moveDirection.Down)
        {
            return this.moveDown;
        }
        else if (direction == moveDirection.Left)
        {
            return this.moveLeft;
        }
        else if (direction == moveDirection.Right)
        {
            return this.moveRight;
        }
        else
        {
            return KeyCode.None;
        }
    }
    private bool isMove(moveDirection direction)
    {
        bool returnValue = false;

        if (Input.GetKey(this.enumToKeyCode(direction)))
        {
            if (SinglePress && this.keyUp[(int)direction])
            {
                this.keyUp[(int)direction] = false;
                returnValue = true;
            }
            else if(!SinglePress)
            {
                returnValue = true;
            }
        }
        else
        {
            this.keyUp[(int)direction] = true;
        }
               
        return returnValue;
    }

    public override bool IsMoveUp()
    {
        return this.isMove(moveDirection.Up);
    }

    public override bool IsMoveDown()
    {
        return this.isMove(moveDirection.Down);
    }

    public override bool IsMoveLeft()
    {
        return this.isMove(moveDirection.Left);
    }

    public override bool IsMoveRight()
    {
        return this.isMove(moveDirection.Right);
    }
}