using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : UIItem
{
    private LevelManager _levelManager;

    [SerializeField]
    private TextMeshProUGUI _counterText;

    [SerializeField]
    private float _timeRemaining;

    private int _minute, _seconds;
    private float _tempTimeRemaining;
    private bool _timerIsRunning;

    private void Start()
    {
        _counterText.text = "0" + _minute.ToString() + ":" + _seconds.ToString();
        _timerIsRunning = true;
        _tempTimeRemaining = _timeRemaining;
    }
    private void Update()
    {
        if (_timerIsRunning)
            ShowCounter(_seconds);

        if (_timeRemaining > 0)
        {
            _minute = Mathf.FloorToInt(_timeRemaining / 60);
            _seconds = Mathf.FloorToInt(_timeRemaining % 60);
            _timeRemaining -= Time.deltaTime;
        }
        else
            LevelEndProcess();
    }
    private void ShowCounter(int seconds)
    {
        if (seconds < 10)
            _counterText.text = "0" + _minute.ToString() + ":" + "0" + ((int)_seconds).ToString();
        else
            _counterText.text = "0" + _minute.ToString() + ":"  + ((int)_seconds).ToString();
    }
    private void LevelEndProcess()
    {
        _timerIsRunning = false;
    }
    public float GetTimeRemaining()
    {
        return _timeRemaining;
    }
}
