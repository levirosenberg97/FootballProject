using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour {

    Rigidbody rb;
    ArriveBehavior ourArrive;
    Vector3 desiredVelocity;
    Vector3 futurePosition;

    //Rigidbody targetRB;

    bool isGrounded = false;

    public float futureDistance;

    public float speed;
    float currentSpeed;

   // public Transform target;

    float dist;

    public float thrust;

    public float acceptableDistance;

    public float burstSpeed;

    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    // Use this for initialization
    void Start ()
    {
        ourArrive = GetComponent<ArriveBehavior>();
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();

//targetRB = target.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Rigidbody targetRB = collision.collider.GetComponent<Rigidbody>();
            if(targetRB != null)
            {
                targetRB.AddForce(transform.forward * thrust);
            }
          
        }
    }

    // Update is called once per frame
    void Update ()
    {
        Collider[] neighbours = Physics.OverlapSphere(transform.position, 3);
        foreach (Collider guy in neighbours)
        {
            if (guy.tag == "enemy")
            {
                ourArrive.target = guy.transform;
            }
        }
    }
}