using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionAreaController : MonoBehaviour
{
    private UIManager _uiManager;

    [SerializeField]
    private Transform _collectionAreaCube;

    private int _cubeCounter;

    private void Start()
    {
        _uiManager = UIManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectCube"))
        {
            _cubeCounter++;
            other.GetComponent<CollectCubeController>().MoveToArea(_collectionAreaCube);
            var counter = _uiManager.FindItem<InGamePanel, CubeCounterController>();
            counter.SetText(_cubeCounter);
        }
    }
    public int GetCubeCounter()
    {
        return _cubeCounter;
    }
}
