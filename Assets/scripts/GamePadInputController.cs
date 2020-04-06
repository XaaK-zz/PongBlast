using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInputController : playerInputController
{
    private int playerControllerNumber;
    private bool leftStick;

    private GamePadInputController(int _playerNumber, bool _leftStick)
    {
        this.playerControllerNumber = _playerNumber;
        this.leftStick = _leftStick;
    }

    static public GamePadInputController CreateGamepadInputController(bool _singlePress, int _playerNumber, bool leftStick = true)
    {
        GamePadInputController controller = new GamePadInputController(_playerNumber, leftStick);
        controller.SinglePress = _singlePress;
        return controller;
    }

    private hStick MovementStick
    {
        get
        {
            return this.leftStick ? hinput.gamepad[this.playerControllerNumber].leftStick : hinput.gamepad[this.playerControllerNumber].rightStick;
        }
    }

    public override bool IsMoveUp()
    {
        if(SinglePress)
        {
            return MovementStick.up.justPressed;
        }
        else
        {
            return MovementStick.up.pressed;
        }
    }

    public override bool IsMoveDown()
    {
        if (SinglePress)
        {
            return MovementStick.down.justPressed;
        }
        else
        {
            return MovementStick.down.pressed;
        }
    }

    public override bool IsMoveLeft()
    {
        if (SinglePress)
        {
            return MovementStick.left.justPressed;
        }
        else
        {
            return MovementStick.left.pressed;
        }
    }

    public override bool IsMoveRight()
    {
        if (SinglePress)
        {
            return MovementStick.right.justPressed;
        }
        else
        {
            return MovementStick.right.pressed;
        }
    }

    public override bool IsDropAction()
    {
        if (SinglePress)
        {
            return hinput.gamepad[this.playerControllerNumber].rightTrigger.justPressed;
        }
        else
        {
            return hinput.gamepad[this.playerControllerNumber].rightTrigger.pressed;
        }
    }
    public override bool IsShiftLeft()
    {
        if (SinglePress)
        {
            return hinput.gamepad[this.playerControllerNumber].leftBumper.justPressed;
        }
        else
        {
            return hinput.gamepad[this.playerControllerNumber].leftBumper.pressed;
        }
    }
    public override bool IsShiftRight()
    {
        if (SinglePress)
        {
            return hinput.gamepad[this.playerControllerNumber].rightBumper.justPressed;
        }
        else
        {
            return hinput.gamepad[this.playerControllerNumber].rightBumper.pressed;
        }
    }
}
