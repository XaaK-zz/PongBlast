using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerInputController 
{
    public bool SinglePress;

    public abstract bool IsMoveUp();
    public abstract bool IsMoveDown();
    public abstract bool IsMoveLeft();
    public abstract bool IsMoveRight();

}

