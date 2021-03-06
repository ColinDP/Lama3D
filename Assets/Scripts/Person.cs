﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Person : MonoBehaviour
{
    [SerializeField] private int speed;
    private Transform[] _checkpoints;
    private Transform _transform;
    private Random _random = new Random();
    private int _index;
    private NavMeshAgent _agent;
    private GameObject theOnlyObjectRegroupingCheckpoints;
    private GameObject[] objectsRegroupingChekpoints;
    private GameObject currentDestinationObject;

    int compteur = 0;

    private void Awake()
    {
        _transform = transform;
        theOnlyObjectRegroupingCheckpoints = GameObject.FindWithTag("checkpoint");
        _checkpoints = GetChildren(theOnlyObjectRegroupingCheckpoints.transform);
        _index = GetRandomPath();
        currentDestinationObject = _checkpoints[_index].gameObject;
        //parent is in table checkpoints on index 0 ==> to change
        _agent = GetComponent<NavMeshAgent>();
        objectsRegroupingChekpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        theOnlyObjectRegroupingCheckpoints = objectsRegroupingChekpoints[0];
    }

    private void Start()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(currentDestinationObject))
        {
            _index = GetRandomPath();
            currentDestinationObject = _checkpoints[_index].gameObject;
            Move();
        }
    }

    private void Move()
    {
        // //rotation
        _transform.rotation =
            Quaternion.Slerp(_transform.rotation,
                Quaternion.LookRotation(_checkpoints[_index].position - _transform.position), speed * Time.deltaTime);
        _agent.SetDestination(_checkpoints[_index].position);
    }

    private int GetRandomPath()
    {
        int i = _random.Next(0, _checkpoints.Length);
        if (i != _index)
        {
            return i;
        }
        return GetRandomPath();
    }

    private Transform[] GetChildren(Transform t)
    {
        List<Transform> result = new List<Transform>(60);
        foreach (Transform child in t)
        {
            result.Add(child);
        }
        return result.ToArray();
    }
}