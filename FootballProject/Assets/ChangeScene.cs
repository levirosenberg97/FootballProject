using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string wool;

    public static float time;

    public void gotoScene()
    {
        SceneManager.LoadScene(wool);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("GameQuit");
    }

    public void addTime()
    {
        time += 30;
    }

    public void removeTime()
    {
        time -= 30;

        if (time <= 0)
        {
            time = 0; // CUZ FUCK U & UR GAME BREAKING SHENNANIGANS
        }
    }


}