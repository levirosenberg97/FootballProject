using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;

    public Text timeText;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;

        var minutes = Mathf.Floor(time / 60);
        var seconds = time % 60;
       

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

	}
}
