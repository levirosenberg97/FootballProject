﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPositions : MonoBehaviour {

    Vector3 originalPos;

	void Start ()
    {
        originalPos = gameObject.transform.position;
	}
	
	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.tag == "ENDZONE MOMMY")
        {
            gameObject.transform.position = originalPos;
        }
	}
}