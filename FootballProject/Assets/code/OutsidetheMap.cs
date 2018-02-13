using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsidetheMap : MonoBehaviour {

    Vector3 newPos = new Vector3(0f,0.6f,0f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathPit")
        {
            gameObject.transform.position = newPos;
        }
    }
}
