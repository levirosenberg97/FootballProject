using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string wool;
	// Use this for initialization

	// Update is called once per frame
	public void gotoScene()
    {
        SceneManager.LoadScene(wool);
   
	}
    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
