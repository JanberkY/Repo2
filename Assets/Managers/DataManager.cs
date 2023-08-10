using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : JSingleton<DataManager>
{
    private const string _levelCounterKey = "LevelKey";
    private const int _levelCounter = 0;
    public override IEnumerator Initialize()
    {
        yield return null;
    }
    public void SetLevel()
    {
        PlayerPrefs.SetInt(_levelCounterKey, _levelCounter + 1);
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt(_levelCounterKey, 0);
    }
}
