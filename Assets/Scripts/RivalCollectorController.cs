using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RivalCollectorController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    public Transform _target;

    [SerializeField]
    public Transform _base;

    private bool _isPoint = true;
    private void Update()
    {
        AgentOperation();
    }
    private void AgentOperation()
    {
        if (_isPoint)
            _agent.SetDestination(_target.position);

        else
            _agent.SetDestination(_base.position);

        if (transform.position.z == _target.position.z)
            _isPoint = false;

        if (transform.position.z == _base.position.z)
            _isPoint = true;
    }
}
