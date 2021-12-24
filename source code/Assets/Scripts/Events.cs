using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("SampleScene");
        if (PlayerManager.levelNo == 1)
        {
            PlayerManager.levelNo = 2;
        }
        else if (PlayerManager.levelNo == 2)
        {
            PlayerManager.levelNo = 3;
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("menu");
    }


}
