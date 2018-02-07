using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglesReset : MonoBehaviour
{

    Vector3 originalPos;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENDZONE DADDY")
        {
            gameObject.transform.position = originalPos;
        }
    }
}