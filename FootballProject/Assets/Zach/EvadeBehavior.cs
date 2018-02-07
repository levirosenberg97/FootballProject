using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeBehavior : MonoBehaviour
{
    Rigidbody rb;

    Vector3 desiredVelocity;

    Vector3 futurePosition;

    Rigidbody targetRB;

    public float futureDistance;

    public float speed;
    float currentSpeed;
    public float burstSpeed;

    public Transform target;

    float dist;
    public float acceptableDistance;

    // Use this for initialization
    void Start()
    {

        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();

        targetRB = target.GetComponent<Rigidbody>();

    }

    public void getAway()
    {
        Collider[] neighbours = Physics.OverlapSphere(transform.position, 2);
        foreach (Collider guy in neighbours)
        {
            if (guy.tag == "Defense")
            {
                target = guy.transform;
            }
        }
        if (target != null)
        {
            dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist > acceptableDistance)
            {
                futurePosition = target.position + (targetRB.velocity * futureDistance);
                desiredVelocity = -(speed * (futurePosition - transform.position).normalized);
                rb.AddForce(desiredVelocity - rb.velocity);
            }
            else
            {
                speed = burstSpeed;
                desiredVelocity = -(speed * (target.position - transform.position).normalized);
                rb.AddForce(desiredVelocity - rb.velocity);
            }
        }


    }


    // Update is called once per frame
    void Update()
    {

    }
}