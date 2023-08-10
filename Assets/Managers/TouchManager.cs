using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TouchManager : JSingleton<TouchManager>
{
    private GameManager _gameManager;
    private IHyperTouch _touch;

    public override IEnumerator Initialize()
    {
        yield return null;
        _gameManager = GameManager.Instance;

        _touch = new JoystickController();
    }
    private void Update()
    {
        if (_touch == null)
            return;

        if (!_gameManager.GetPlayable())
            return;

        _touch.Click();
    }
    private void FixedUpdate()
    {
        if (_touch == null)
            return;

        if (!_gameManager.GetPlayable())
            return;

        _touch.Handle();
    }
    public IHyperTouch ClickData()
    {
        if (_touch == null)
            Debug.LogError("there is no referance in \"touch\" ");

        return _touch;
    }
}
public class TouchData
{
    public float Vertical, Horizontal;

    public Vector2 FirstPos;
    public Vector2 CurrentPos;

    public RaycastHit Hit;
    public bool HitExists;
}
