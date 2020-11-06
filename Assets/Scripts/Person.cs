using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Person : MonoBehaviour
{
    [SerializeField]private GameObject checkpoint;
    [SerializeField] private int speed;
    private Transform[] checkpoints;
    private Transform _transform;
    private int index = 1;

    private void Awake()
    {
        _transform = transform;
        checkpoint = GameObject.FindWithTag("checkpoint");
        checkpoints = checkpoint.GetComponentsInChildren<Transform>();
        //parent is in table checkpoints on index 0 ==> to change
        foreach (var check in checkpoints)
        {
            print(check.name);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("point"))
        {
            print("Collision ==> NEXT WAY");
            index++;
        } 
    }
    private void Move()
    {
        Vector3 direction = checkpoints[index].position - _transform.position;
        direction = direction.normalized * (speed * Time.deltaTime);
        _transform.Translate(direction);
    }
}
