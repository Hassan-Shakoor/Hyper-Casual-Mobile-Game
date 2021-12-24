using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class eventsLevel : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerManager.levelNo = 1;
    }

    public void level2()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerManager.levelNo = 2;
    }

    public void level3()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerManager.levelNo = 3;
    }


    public void mainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
