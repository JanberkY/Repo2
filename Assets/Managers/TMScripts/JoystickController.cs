using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : IHyperTouch
{
    public event Action<TouchData> DownClick;
    public event Action<TouchData> UpClick;
    public event Action<TouchData> SetClick;

    private TouchData _touchData;
    private JoystickUIItem _uiItem;

    public JoystickController()
    {
        _touchData = new TouchData();

        var uiManager = UIManager.Instance;
        _uiItem = uiManager.FindItem<JoystickPanel, JoystickUIItem>();

    }
    public void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchData.FirstPos = Input.mousePosition;
            Assign(ref DownClick);
        }

        else if (Input.GetMouseButton(0))
        {
            Assign(ref SetClick);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Assign(ref UpClick);
        }
    }
    private void Assign(ref Action<TouchData> action)
    {
        _touchData.Horizontal = _uiItem.GetHorizontal();
        _touchData.Vertical = _uiItem.GetVertical();
        _touchData.CurrentPos = Input.mousePosition;

        action?.Invoke(_touchData);
    }

    public void Handle()
    {
        
    }
}
public enum ClickControl
{
    Empty, Down, Set, Up
}
