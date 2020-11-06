using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(NavMeshAgent))]
public class Virus : MonoBehaviour
{

    [SerializeField] private GameObject target;
    public static GameObject[] players;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("player");
        target = players[0];
    }

    private void Update()
    {
        MoveToTarget();
    }
    
    private void MoveToTarget()
    {
        _agent.SetDestination((target.transform.position));
    }

    void Start()
    {
        
    }

}
