using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefensiveBehavior : MonoBehaviour
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
	void Start ()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();

        targetRB = target.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            if(target.transform.parent == null)
            {
                target.transform.position = transform.position + new Vector3(.089f,1.205f,-.089f);
                targetRB.isKinematic = true;
                targetRB.useGravity = false;
                target.transform.parent = transform;
            }
        }

        if (collision.collider.tag == "Offense" && collision.collider.transform.childCount == 4)
        {
            target.transform.parent = null;
            targetRB.isKinematic = false;
            targetRB.useGravity = true;
           
        }
    }
    // Update is called once per frame
    void Update ()
    {
        dist = Vector3.Distance(transform.position, target.position);

        if (dist > acceptableDistance)
        {
            futurePosition = target.position + (targetRB.velocity * futureDistance);
            desiredVelocity = speed * (futurePosition - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
        else
        {
            speed = burstSpeed;
            desiredVelocity = speed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
    }
}
