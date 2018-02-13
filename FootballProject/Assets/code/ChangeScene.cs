using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string wool;

    public void gotoScene()
    {
        SceneManager.LoadScene(wool);
    }


    public void exitGame()
    {
        Application.Quit();
        Debug.Log("GameQuit");
    }

}
 