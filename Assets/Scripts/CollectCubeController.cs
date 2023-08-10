using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectCubeController : MonoBehaviour
{
    [SerializeField]
    private GameObject _myChild;

    [SerializeField]
    private MeshRenderer _myMesh;

    [SerializeField]
    private Rigidbody _rigidbody;

    public void MoveToArea(Transform t)
    {
        transform.DOMoveZ(t.position.z, 0.5f).OnComplete(() =>
        {
            _myMesh.enabled = false;
            _myChild.SetActive(true);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.freezeRotation = true;
            transform.tag = "Untagged";
            gameObject.layer = LayerMask.NameToLayer("Default");
        });
    }
}
