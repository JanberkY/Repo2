using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

public class LevelGenerator : JSingleton<LevelGenerator>
{
    private UIManager _uiManager;

    public Texture2D Image;
    public ObjectPool Pool;
    public float CubeSize;
    public float YOffset, XOffset, ZOffset;

    public LevelType SelectLevelType;

    [SerializeField]
    private List<GameObject> _levelList;

    [SerializeField]
    private Transform _cubeCreateTransform;

    [SerializeField]
    private CollectorScriptable _collectorValues;

    private bool _loopCreateCube = true;

    public override IEnumerator Initialize()
    {
        yield return null;

        _uiManager = UIManager.Instance;

        if (SelectLevelType == LevelType.CubeCreateLevel)
        {
            StartCoroutine(GenerateCreateCubeLevel());
            Instantiate(_levelList[0]);
        }
        if (SelectLevelType == LevelType.TimeChallangeLevel)
        {
            Instantiate(_levelList[1]);
            _uiManager.FindPanel<InGamePanel>().OpenPanel();
            _uiManager.FindItem<InGamePanel, RivalCubeCounterController>().CloseItem();
            StartCoroutine(GenerateTimeChallangeLevel());
        }
        if (SelectLevelType == LevelType.RivalLevel)
        {
            Instantiate(_levelList[2]);
            _uiManager.FindPanel<InGamePanel>().OpenPanel();
            StartCoroutine(GenerateCreateCubeLevel());
        }
        if (SelectLevelType == LevelType.ImageLevel)
        {
            Instantiate(_levelList[3]);
            GenerateImageLevel();
        }
    }
    private void GenerateImageLevel()
    {
        int width = Image.width;
        int height = Image.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixelColor = Image.GetPixel(x, y);

                if (pixelColor.a > 0.5f)
                {
                    Vector3 position = new Vector3(x * CubeSize - XOffset, YOffset, y * CubeSize - ZOffset);
                    var cube = Pool.GetFromPool();
                    cube.transform.position = position;

                    cube.transform.localScale = new Vector3(CubeSize, CubeSize, CubeSize);

                    Renderer cubeRenderer = cube.transform.GetChild(0).GetComponent<Renderer>();
                    cubeRenderer.material.color = pixelColor;
                }
            }
        }
    }
    private IEnumerator GenerateCreateCubeLevel()
    {
        while (_loopCreateCube)
        {
            var cube = Pool.GetFromPool();
            cube.transform.position = _cubeCreateTransform.position;
            var random = Random.Range(-3, 3);
            cube.transform.DOJump(new Vector3(_cubeCreateTransform.position.x - random, _cubeCreateTransform.position.y, _cubeCreateTransform.position.z), 5f, 1, 0.1f);

            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator GenerateTimeChallangeLevel()
    {
        while (_loopCreateCube)
        {
            var timer = _uiManager.FindItem<InGamePanel, TimerController>().GetTimeRemaining();
            var cube = Pool.GetFromPool();
            cube.transform.position = _cubeCreateTransform.position;

            yield return new WaitForSeconds(0.5f);

            if (timer <= 0)
                _loopCreateCube = false;
        }
    }
    public float GetMovementSpeed()
    {
        return _collectorValues.CharacterMovementSpeed;
    }
    public float GetRotationSpeed()
    {
        return _collectorValues.CharacterRotationSpeed;
    }
    public float GetCollectorMovementDelay()
    {
        return _collectorValues.MovementDelay;
    }
}
public enum LevelType
{
    CubeCreateLevel, TimeChallangeLevel, RivalLevel, ImageLevel
}
