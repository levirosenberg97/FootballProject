using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footballBehavior : MonoBehaviour
{
    Rigidbody rb;

    Vector3 desiredVelocity;

    Vector3 futurePosition;

    Rigidbody targetRB;

    Rigidbody evadeTargetRB;

    public float futureDistance;

    public float speed;

    float currentSpeed;
    public float burstSpeed;

    public Transform defenseTarget;

    public Transform offenseTarget;

    public Transform evadeTarget;

    float dist;
    public float acceptableDistance;

    bool isGrounded;

    ArriveBehavior ourArrive;

    public float thrust;


    void tagSwitch()
    {
        if (transform.childCount == 4)
        {
            transform.tag = "BallCarrier";
            return;
        }

        if (defenseTarget.parent.parent.tag == "Eagle" &&  transform.parent.tag == "Eagle")
        {
            transform.tag = "Offense";
            return;
        }

        if(defenseTarget.parent.parent.tag == "Patriot" && transform.parent.tag == "Eagle" || defenseTarget.parent == null)
        {
            transform.tag = "Defense";
            return;
        }

        if (defenseTarget.parent.parent.tag == "Patriot" && transform.parent.tag == "Patriot")
        {
            transform.tag = "Offense";
            return;
        }

        if (defenseTarget.parent.parent.tag == "Eagle" && transform.parent.tag == "Patriot" || defenseTarget.parent == null)
        {
            transform.tag = "Defense";
            return;
        }

        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (transform.tag == "Defense")
        {
            if (collision.collider.tag == "Ball")
            {
                if (defenseTarget.transform.parent == null)
                {
                    defenseTarget.transform.position = transform.position + new Vector3(.089f, 1.205f, -.089f);
                    targetRB.isKinematic = true;
                    targetRB.useGravity = false;
                    defenseTarget.transform.parent = transform;
                }
            }

            if (collision.collider.tag == "BallCarrier" && collision.collider.transform.childCount == 4)
            {
                defenseTarget.transform.parent = null;
                targetRB.isKinematic = false;
                targetRB.useGravity = true;
            }

        }

        if(transform.tag == "Offense")
        {

            if (collision.collider.tag == "Defense")
            {
                Rigidbody targetRB = collision.collider.GetComponent<Rigidbody>();
                if (targetRB != null)
                {
                    targetRB.AddForce(transform.forward * thrust);
                }

            }
        }


    }



    // Use this for initialization
    void Start()
    {
        isGrounded = true;

        rb = GetComponent<Rigidbody>();
        ourArrive = GetComponent<ArriveBehavior>();
        currentSpeed = speed;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.tag == "Defense")
        {
            //Defensive Behavior
            targetRB = defenseTarget.GetComponent<Rigidbody>();
            dist = Vector3.Distance(transform.position, defenseTarget.position);

            if (dist > acceptableDistance)
            {
                futurePosition = defenseTarget.position + (targetRB.velocity * futureDistance);
                desiredVelocity = speed * (futurePosition - transform.position).normalized;
                rb.AddForce(desiredVelocity - rb.velocity);
            }
            else
            {
                speed = burstSpeed;
                desiredVelocity = speed * (defenseTarget.position - transform.position).normalized;
                rb.AddForce(desiredVelocity - rb.velocity);
            }
        }

        if(transform.tag == "Offense")
        {
            //Arrive
            targetRB = offenseTarget.GetComponent<Rigidbody>();

            Vector3 targetOnY = offenseTarget.position;
            targetOnY.y = transform.position.y;
            Vector3 targetOffset = offenseTarget.position - transform.position;
            float dist = Vector3.Distance(transform.position, offenseTarget.position);
            float rampedSpeed = speed * (targetOffset.magnitude / dist);
            float clippedSpeed = Mathf.Min(rampedSpeed, speed);
            Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
            desiredVelocity.y = 0;
            rb.AddForce(desiredVelocity - rb.velocity);


            //Blocking
            Collider[] neighbours = Physics.OverlapSphere(transform.position, 3);
            foreach (Collider guy in neighbours)
            {
                if (guy.tag == "Defense")
                {
                    ourArrive.target = guy.transform;
                }
            }
        }

        if(transform.tag == "BallCarrier")
        {
            //Arrive
            targetRB = offenseTarget.GetComponent<Rigidbody>();

            Vector3 targetOnY = offenseTarget.position;
            targetOnY.y = transform.position.y;
            Vector3 targetOffset = offenseTarget.position - transform.position;
            float dist = Vector3.Distance(transform.position, offenseTarget.position);
            float rampedSpeed = speed * (targetOffset.magnitude / dist);
            float clippedSpeed = Mathf.Min(rampedSpeed, speed);
            Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
            desiredVelocity.y = 0;
            rb.AddForce(desiredVelocity - rb.velocity);

            //Evade

            evadeTargetRB = evadeTarget.GetComponent<Rigidbody>();
            Collider[] neighbours = Physics.OverlapSphere(transform.position, 2);
            foreach (Collider guy in neighbours)
            {
                if (guy.tag == "Defense")
                {
                    evadeTarget = guy.transform;
                }
            }
            if (evadeTarget != null)
            {
                dist = Vector3.Distance(transform.position, evadeTarget.transform.position);
                if (dist > acceptableDistance)
                {
                    futurePosition = evadeTarget.position + (evadeTargetRB.velocity * futureDistance);
                    desiredVelocity = -(speed * (futurePosition - transform.position).normalized);
                    rb.AddForce(desiredVelocity - rb.velocity);
                }
                else
                {
                    speed = burstSpeed;
                    desiredVelocity = -(speed * (evadeTarget.position - transform.position).normalized);
                    rb.AddForce(desiredVelocity - rb.velocity);
                }
            }

        }
        tagSwitch();
	}
}
