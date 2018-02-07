using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Team
{
    patriot,
    eagle

}


public class Coach : MonoBehaviour {


    public List<Jersey> players;


    public void switchToOffense()
    {
        for(int i =0; i < players.Count; i++)
        {
            players[i].play = PlayBook.offense;
        }
    }


    // Use this for initialization
    void Start ()
    {
        players = new List<Jersey>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		for (int i = 0; i< players.Count; i++)
        {
            if (players[i].transform.childCount == 4)
            {
                switchToOffense();
                players[i].play = PlayBook.haveTheBall;
            }
        }
	}
}
