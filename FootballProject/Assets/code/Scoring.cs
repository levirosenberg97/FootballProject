﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    bool hasBall;
    public float score;
    public scoreManager manager;
    public string endzone;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == endzone && hasBall == true)
        {
            manager.currentEaglesScore += score;
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
