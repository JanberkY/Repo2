using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : JSingleton<GameManager>
{
    private bool _playable = true;
    public override IEnumerator Initialize()
    {
        yield return null;
    }
    public void SetPlayable(bool playable)
    {
        _playable = playable;
    }
    public bool GetPlayable()
    {
        return _playable;
    }
}
