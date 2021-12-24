using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1;
    }

    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerManager.levelNo = 1;
    }

    public void levelScreen()
    {
        SceneManager.LoadScene("levelScreen");
    }

    public void rulesScreen()
    {
        SceneManager.LoadScene("rulesScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
