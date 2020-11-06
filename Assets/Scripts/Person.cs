using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Person : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint;
    [SerializeField] private int speed;
    private Transform[] _checkpoints;
    private Transform _transform;
    private Random _random = new Random();
    private int _index;

    int compteur = 0;

    private void Awake()
    {
        _transform = transform;
        checkpoint = GameObject.FindWithTag("checkpoint");
        _checkpoints = GetChildren(checkpoint.transform);
        _index = GetRandomPath();
        //parent is in table checkpoints on index 0 ==> to change
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("point"))
        {
            _index = GetRandomPath();
            print(compteur++);
        }
    }
    

    private void Move()
    {
        //rotation
        _transform.rotation =
            Quaternion.Slerp(_transform.rotation,
                Quaternion.LookRotation(_checkpoints[_index].position - _transform.position), speed * Time.deltaTime);
        
        //direction
        Vector3 direction = _checkpoints[_index].position - _transform.position;
        direction = direction.normalized * (speed * Time.deltaTime);
        //print(_checkpoints[_index].position)
        _transform.Translate(direction, Space.World);
    }

    private int GetRandomPath()
    {
        int i = _random.Next(1, _checkpoints.Length);
        print("PREV : " + _index);
        if (i != _index)
        {
            print("Current : " + i);
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