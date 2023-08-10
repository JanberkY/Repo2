using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CollectorController : MonoBehaviour
{
    private TouchManager _touchManager;
    private LevelGenerator _levelGenerator;
    private UIManager _uiManager;

    [SerializeField]
    private Rigidbody _rigidbody;

    private Vector3 _direction, _movement;

    private void Start()
    {
        _touchManager = TouchManager.Instance;
        _levelGenerator = LevelGenerator.Instance;
        _uiManager = UIManager.Instance;
        TouchInitiliaze();
    }
    private void TouchInitiliaze()
    {
        _touchManager.ClickData().DownClick -= Down;
        _touchManager.ClickData().SetClick -= Set;
        _touchManager.ClickData().UpClick -= Up;

        _touchManager.ClickData().DownClick += Down;
        _touchManager.ClickData().SetClick += Set;
        _touchManager.ClickData().UpClick += Up;

        _uiManager.FindPanel<JoystickPanel>().OpenPanel();
    }
    private void Down(TouchData obj)
    {

    }
    private void Set(TouchData obj)
    {
        _movement = new Vector3(obj.Horizontal, 0f, obj.Vertical) * _levelGenerator.GetMovementSpeed();
        _rigidbody.velocity = _movement;
        _direction = new Vector3(obj.Horizontal, 0f, obj.Vertical);

        if (_direction.magnitude > 0.01f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(_direction);
            _rigidbody.MoveRotation(lookRotation);
        }
    }
    private void Up(TouchData obj)
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
