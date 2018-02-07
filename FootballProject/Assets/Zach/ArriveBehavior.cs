using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public Transform target;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void arriveAtpoint()
    {
        Vector3 targetOnY = target.position;
        targetOnY.y = transform.position.y;
        Vector3 targetOffset = target.position - transform.position;
        float dist = Vector3.Distance(transform.position, target.position);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        desiredVelocity.y = 0;
        rb.AddForce(desiredVelocity - rb.velocity);
    }

    private void Update()
    {
       
    }
}