using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public scoreManager scoreTracker;

    Vector3 originalPos;
    
    float eaglesScore;
    float patriotsScore;
    

	// Use this for initialization
	void Start ()
    {
        originalPos = gameObject.transform.position;
        eaglesScore = 0;
        patriotsScore = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scoreTracker.currentEaglesScore > eaglesScore)
        {
            gameObject.transform.parent = null;
            gameObject.transform.position = originalPos;
            eaglesScore = scoreTracker.currentEaglesScore;
        }

        if(scoreTracker.currentPatsScore > patriotsScore)
        {
            gameObject.transform.parent = null;
            gameObject.transform.position = originalPos;
            patriotsScore = scoreTracker.currentPatsScore;
        }

        

	}
}
