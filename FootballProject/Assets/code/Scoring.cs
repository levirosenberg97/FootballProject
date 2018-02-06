using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    bool hasBall;
    public float score;
    public scoreManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ENDZONE DADDY" && transform.tag == "Eagle")
        {
            manager.currentEaglesScore += score;
        }

        if(other.tag == "ENDZONE MOMMY" && transform.tag == "Patriot")
        {
            manager.currentPatsScore += score;
        }
    }


    private void Update()
    {
        if (transform.childCount > 3)
        {
            hasBall = true;
        }
        else
        {
            hasBall = false;
        }

        
    }
}
