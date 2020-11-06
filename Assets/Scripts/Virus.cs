using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(NavMeshAgent))]
public class Virus : MonoBehaviour
{

    [SerializeField] private Transform target;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetButton("Jump"))
            MoveToTarget();
    }
    
    private void MoveToTarget()
    {
        _agent.SetDestination((target.position));
    }

    void Start()
    {
        
    }

}
