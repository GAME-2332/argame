using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Enemychase : MonoBehaviour
{
    public float moveSpeed = .01f;
    public float _range = 5f;
    public float _force = 4f;
    
    Transform target;
    Vector3 direction;
    

    Rigidbody rb;

    

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
         rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(target.position, transform.position) < 5)
        {
            // Vector3 a = transform.position;
            // Vector3 b = target.position;
            // transform.position = Vector3.Lerp(a, b, moveSpeed);
            direction = target.position - transform.position;
            rb.AddForce(direction * moveSpeed, ForceMode.Impulse);
        }
    }


    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
