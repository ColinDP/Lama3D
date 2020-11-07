using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private const float Speed = 5;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _currentVelocity;
    private NavMeshAgent _agent;
    private RaycastHit hit;

    private void Awake()
    {
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
        _currentVelocity = Speed * direction;
        _currentVelocity.y = _rigidbody.velocity.y;
        
        //??
        // _transform.Rotate(new Vector3(0, hInput, 0) * 2f);
        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _currentVelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("person"))
        {
            print("Person détectée");
            if (Physics.Raycast(transform.position, other.transform.position-transform.position, out hit))
            {
                print(hit.collider.gameObject.name);
                if (!hit.collider.gameObject.CompareTag("person"))
                {
                    print("Obstacle entre player et person : " + hit.collider.name);
                }
                else
                {
                    GameManager.GameManager.Instance.LoadScene("GameOver");
                }
            }
        }
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