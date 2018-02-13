using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangedText : MonoBehaviour {

    public Text changedTimeText;
    
	
	// Update is called once per frame
	void Update ()
    {
        changedTimeText.text = "How long should the Program Run?: " + ChangeScene.time + " Sec";
	}
}
