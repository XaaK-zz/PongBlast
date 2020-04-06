using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeyboardInputController : playerInputController
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode dropAction = KeyCode.Space;
    public KeyCode shiftLeft = KeyCode.Q;
    public KeyCode shiftRight = KeyCode.E;


    protected bool[] keyUp = { true, true, true, true, true, true, true };
    private enum keyPressOptions { Up, Down, Left, Right, Action, ShiftLeft, ShiftRight};

    private KeyboardInputController(KeyCode _moveUp, KeyCode _moveDown, KeyCode _moveLeft, KeyCode _moveRight,KeyCode _drop, KeyCode _shiftLeft, KeyCode _shiftRight)
    {
        this.moveUp = _moveUp;
        this.moveDown = _moveDown;
        this.moveLeft = _moveLeft;
        this.moveRight = _moveRight;
        this.dropAction = _drop;
        this.shiftLeft = _shiftLeft;
        this.shiftRight = _shiftRight;
    }

    static public KeyboardInputController CreateKeyboardInputController(bool _singlePress, KeyCode _moveUp, KeyCode _moveDown, KeyCode _moveLeft = KeyCode.None, KeyCode _moveRight = KeyCode.None,
        KeyCode _drop = KeyCode.None, KeyCode _shiftLeft = KeyCode.None, KeyCode _shiftRight = KeyCode.None)
    {
        KeyboardInputController controller = new KeyboardInputController(_moveUp, _moveDown, _moveLeft, _moveRight, _drop, _shiftLeft, _shiftRight);
        controller.SinglePress = _singlePress;
        return controller;
    }

    private KeyCode enumToKeyCode(keyPressOptions _keyPress)
    {
        if (_keyPress == keyPressOptions.Up)
        {
            return this.moveUp;
        }
        else if(_keyPress == keyPressOptions.Down)
        {
            return this.moveDown;
        }
        else if (_keyPress == keyPressOptions.Left)
        {
            return this.moveLeft;
        }
        else if (_keyPress == keyPressOptions.Right)
        {
            return this.moveRight;
        }
        else if (_keyPress == keyPressOptions.Action)
        {
            return this.dropAction;
        }
        else
        {
            return KeyCode.None;
        }
    }
    private bool isValidKeyPress(keyPressOptions _keyPress)
    {
        bool returnValue = false;

        if (Input.GetKey(this.enumToKeyCode(_keyPress)))
        {
            if (SinglePress && this.keyUp[(int)_keyPress])
            {
                this.keyUp[(int)_keyPress] = false;
                returnValue = true;
            }
            else if(!SinglePress)
            {
                returnValue = true;
            }
        }
        else
        {
            this.keyUp[(int)_keyPress] = true;
        }
               
        return returnValue;
    }

    public override bool IsMoveUp()
    {
        return this.isValidKeyPress(keyPressOptions.Up);
    }

    public override bool IsMoveDown()
    {
        return this.isValidKeyPress(keyPressOptions.Down);
    }

    public override bool IsMoveLeft()
    {
        return this.isValidKeyPress(keyPressOptions.Left);
    }

    public override bool IsMoveRight()
    {
        return this.isValidKeyPress(keyPressOptions.Right);
    }

    public override bool IsDropAction()
    {
        return this.isValidKeyPress(keyPressOptions.Action);
    }
    public override bool IsShiftLeft()
    {
        return this.isValidKeyPress(keyPressOptions.ShiftLeft);
    }
    public override bool IsShiftRight()
    {
        return this.isValidKeyPress(keyPressOptions.ShiftRight);
    }
}