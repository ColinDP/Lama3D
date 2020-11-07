﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _currentVelocity;
    private NavMeshAgent _agent;
    private RaycastHit hit;

    private void Awake()
    {
        speed = 5;
        _rigidbody =  GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
        var hInput = Input.GetAxisRaw("Horizontal");
        var vInput = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(-vInput, 0, hInput).normalized;
        _currentVelocity = speed * direction;
        _currentVelocity.y = _rigidbody.velocity.y;
        
        //??
        // _transform.Rotate(new Vector3(0, hInput, 0) * 2f);
        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _currentVelocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.tag.Equals("ground"))
        {
            print("collision");
        }
        //UnityEvent ??
        if (other.gameObject.tag.Equals("virusagent"))
        {
            print("INFECTED BY VIRUS");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("person"))
        {
            print("Person détectée");
            if (Physics.Raycast(transform.position, other.transform.position-transform.position, out hit))
            {
                if (!hit.collider.gameObject.CompareTag("person"))
                {
                    print("Obstacle entre player et person : " + hit.collider.name);
                }
                else
                {
                    print("INFECTED BY VIRUS");
                }
            }
        }
    }


    public float Speed
    {
        get => speed;
        set => speed = value;
    }
}