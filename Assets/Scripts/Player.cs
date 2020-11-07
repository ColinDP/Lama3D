using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private const float Speed = 5;
    private Rigidbody _rigidbody;
    private Vector3 _currentVelocity;
    
    private void Awake()
    {
        _rigidbody =  GetComponent<Rigidbody>();
    }
    private void Update()
    {
        var hInput = Input.GetAxisRaw("Horizontal");
        var vInput = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(-vInput, 0, hInput).normalized;

        _currentVelocity = Speed * direction;
        _currentVelocity.y = _rigidbody.velocity.y;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("ground"))
        {
            print("trigger");
        }
    }
}