using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public float currentPatsScore;
    public float currentEaglesScore;
    // Use this for initialization
    public Text patsText;
    public Text eaglesText;
	
	// Update is called once per frame
	void Update ()
    {
        patsText.text = currentPatsScore.ToString();
        eaglesText.text = currentEaglesScore.ToString();
	}
}
