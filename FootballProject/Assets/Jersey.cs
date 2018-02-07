using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayBook
{
    offense,
    defense,
    haveTheBall

}


public class Jersey : MonoBehaviour {

    public Team team;
    ArriveBehavior arrive;
    Blocking block;
    DefensiveBehavior defense;
    EvadeBehavior evade;
    public PlayBook play;
    Coach myCoach;
    public GameObject endzone;
	// Use this for initialization
	void Start ()
    {
        myCoach = transform.parent.GetComponent<Coach>();
        myCoach.players.Add(this);
        arrive = GetComponent<ArriveBehavior>();
        evade = GetComponent<EvadeBehavior>();
        block = GetComponent<Blocking>();
        defense = GetComponent<DefensiveBehavior>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (play)
        {
            case PlayBook.haveTheBall:
                //Do ball stuff
                evade.getAway();               
                arrive.target = endzone.transform;
                arrive.arriveAtpoint();
                break;
            case PlayBook.offense:
                arrive.target = endzone.transform;
                arrive.arriveAtpoint();
                
                //do offense
                break;
            case PlayBook.defense:

                //do defense
                break;
        }
        
	}
}
