using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickUIItem : UIItem
{
    [SerializeField]
    private VariableJoystick _joystick;

    public float GetVertical()
    {
        return _joystick.Vertical;
    }
    public float GetHorizontal()
    {
        return _joystick.Horizontal;
    }
}
