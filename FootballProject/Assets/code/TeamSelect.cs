using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamSelect : MonoBehaviour
{

    public Text changedTeamText;

    public static GameObject[] gameObjects;

    public static Material SeahawksBlue;
    public static Material PatriotsBlue;
    public static Material BrownsOrange;
    public static Material FalconsRed;
    public static Material RavensPurple;
    public static Material EaglesGreen;

    public static RawImage Eagles;
    public static RawImage Patriots;
    public static RawImage Seahawks;
    public static RawImage Browns;
    public static RawImage Falcons;
    public static RawImage Ravens;


    public Material baseMaterial;

    // Update is called once per frame
    void Update()
    {
        changedTeamText.text = "Which teams should play? ";
    }

    public void AssignMaterial()
    {
        foreach(var obj in gameObjects)
        {
            obj.GetComponent<Renderer>().sharedMaterial = baseMaterial;
        }
    }

    public void AssignImage()
    {
        
    }

    public void addEagles()
    {
        baseMaterial = EaglesGreen;
        AssignMaterial(); 
        //baseImage = Eagles;
    }

    public void addPatriots()
    {
        baseMaterial = PatriotsBlue;
        AssignMaterial();
        //baseImage = Patriots;
    }

    public void addSeahawks()
    {
        baseMaterial = SeahawksBlue;
        AssignMaterial();
        //baseImage = Seahawks;
    }

    public void addBrowns()
    {
        baseMaterial = BrownsOrange;
        AssignMaterial();
        //baseImage = Browns;
    }

    public void addFalcons()
    {
        baseMaterial = FalconsRed;
        AssignMaterial();
        //baseImage = Falcons;
    }

    public void addRavens()
    {
        baseMaterial = RavensPurple;
        AssignMaterial();
        //baseImage = Ravens;
    }
}