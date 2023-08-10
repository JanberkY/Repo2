using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderManager : JSingleton<LoaderManager>
{
    private void Start()
    {
        StartCoroutine(Initialize());
    }
    public override IEnumerator Initialize()
    {
        yield return null;

        var poolManager = StartCoroutine(PoolManager.Instance.Initialize());
        yield return poolManager;

        var touchManager = StartCoroutine(TouchManager.Instance.Initialize());
        yield return touchManager;

        var dataManager = StartCoroutine(DataManager.Instance.Initialize());
        yield return dataManager;

        var uiManager = StartCoroutine(UIManager.Instance.Initialize());
        yield return uiManager;

        var gameManager = StartCoroutine(GameManager.Instance.Initialize());
        yield return gameManager;

        var levelManager = StartCoroutine(LevelManager.Instance.Initialize());
        yield return levelManager;

        var levelGenerator = StartCoroutine(LevelGenerator.Instance.Initialize());
        yield return levelGenerator;
    }
}
