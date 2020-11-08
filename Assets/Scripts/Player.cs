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
    private bool _invincible;

    public bool IsInvincible()
    {
        return _invincible;
    }

    public void SetInvincible(bool val)
    {
        _invincible = val;
    }
    private NavMeshHit navmeshhit;

    private void Awake()
    {
        speed = 5;
        _invincible = false;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("person"))
        {
            Vector3 origin = transform.localPosition;
            Vector3 direction = other.transform.localPosition;
            if (!NavMesh.Raycast(origin, direction, out navmeshhit, NavMesh.AllAreas))
            {
                // gameObject.GetComponent<Rigidbody>().GetComponent<IDeath>()?.OnDeath();
                print("MORT");
            }
            else
            {
                print("pas mort");
            }
        }
    }
    
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     StartCoroutine(DangerZone());
    // }
    //
    // IEnumerator DangerZone()
    // {
    //     yield return new WaitForSeconds((float)2);
    //     GameManager.GameManager.Instance.LoadScene("GameOver");
    // }
}