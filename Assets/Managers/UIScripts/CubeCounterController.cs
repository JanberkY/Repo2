using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeCounterController : UIItem
{
    [SerializeField]
    private TextMeshProUGUI _cubeCounterText;

    private void Start()
    {
        _cubeCounterText.text = "0";
    }
    public void SetText(int counter)
    {
        _cubeCounterText.text = counter.ToString();
    }
}
