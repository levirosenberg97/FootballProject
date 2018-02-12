using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPositions : MonoBehaviour {
    
    Vector3 originalPos;
    public scoreManager AlRoker;
    float EaglesScore = 0f;
    float PatriotsScore = 0.0f;
    Rigidbody rb;
    Quaternion originalRotation;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        originalPos = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathPit")
        {
            gameObject.transform.position = originalPos;

            gameObject.transform.rotation = originalRotation;

            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void Update()
    {
       

        if (AlRoker.currentEaglesScore > EaglesScore)
        {
            EaglesScore = AlRoker.currentEaglesScore;
            
            gameObject.transform.position = originalPos;

            gameObject.transform.rotation = originalRotation;

            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        if (AlRoker.currentPatsScore > PatriotsScore)
        {
            PatriotsScore = AlRoker.currentPatsScore;
            gameObject.transform.position = originalPos;
            gameObject.transform.rotation = originalRotation;

            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
        
    

    //    if (other.tag == "ENDZONE DADDY" || other.tag == "ENDZONE MOMMY")
    //    {
    //        if (AlRoker.currentEaglesScore > EaglesScore)
    //        {
    //            gameObject.transform.position = originalPos;
    //        }

    //        if (AlRoker.currentPatsScore > PatriotsScore)
    //        {
    //            gameObject.transform.position = originalPos;
    //        }
    //    }
    //}











}