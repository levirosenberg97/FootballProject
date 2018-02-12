using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    public scoreManager geneStarator;
    public Text timeText;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;

        var minutes = Mathf.Floor(time / 60);
        var seconds = time % 60;
       

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
       
        if (time <= 0.0f)
        {
            if ( geneStarator.currentEaglesScore > geneStarator.currentPatsScore)
            {
               SceneManager.LoadScene("EaglesWin");
            }
            else if (geneStarator.currentPatsScore > geneStarator.currentEaglesScore)
            {
                SceneManager.LoadScene("PatriotsWin");
            }
            else if (geneStarator.currentEaglesScore == geneStarator.currentPatsScore)
            {
                time = 300;
            }
        }

	}
}
