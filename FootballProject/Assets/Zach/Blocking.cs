using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour {

    Rigidbody rb;

    Vector3 desiredVelocity;
    Vector3 futurePosition;

    Rigidbody targetRB;

    public float futureDistance;

    public float speed;
    float currentSpeed;

    public Transform target;

    float dist;

    public float thrust;

    public float acceptableDistance;

    public float burstSpeed;

    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    // Use this for initialization
    void Start ()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();

        targetRB = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        Collider[] neighbours = Physics.OverlapSphere(transform.position, 3);
        foreach (Collider guy in neighbours)
        {
            if (guy.tag == "enemy")
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

        rb.AddForce(transform.forward * thrust);
    }
}