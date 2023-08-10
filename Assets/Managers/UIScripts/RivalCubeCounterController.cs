using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RivalCubeCounterController : UIItem
{
    [SerializeField]
    private TextMeshProUGUI _rivalCubeCounterText;

    private void Start()
    {
        _rivalCubeCounterText.text = "0";
    }
    public void SetText(int counter)
    {
        _rivalCubeCounterText.text = counter.ToString();
    }
}
