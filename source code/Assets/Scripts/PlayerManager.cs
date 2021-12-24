using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver,isGameStarted;
    public static int levelNo;
    public Text energyText;
    public GameObject gameOverPanel;
    public GameObject gameWonPanel;
    public Image progressBarColor;
    public Slider progressBar;
    public Button nextLevelBtn;

    public Text startingText;
    public static int energyNo;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        energyNo = 0;
        energyText.text = "0";
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
        player = GameObject.Find("Player");
        progressBar.value = 0;
        startingText.text = "Level " + levelNo + "\nTAP TO START!";
    }

    // Update is called once per frame
    void Update()
    {
        if (energyNo < 0){
            gameOver = true;
        }

        if (gameOver)
        {
            Time.timeScale = 0;
            if (levelNo == 1)
            {
                if (PlayerManager.energyNo < 20)
                {
                    gameOverPanel.SetActive(true);
                }
                else
                {
                    gameWonPanel.SetActive(true);
                    nextLevelBtn.interactable = true;
                }
            }
            if (levelNo == 2)
            {
                if (PlayerManager.energyNo < 25)
                {
                    gameOverPanel.SetActive(true);
                }
                else
                {
                    gameWonPanel.SetActive(true);
                    nextLevelBtn.interactable = true;
                }
            }
            if (levelNo == 3)
            {
                if (PlayerManager.energyNo < 30)
                {
                    gameOverPanel.SetActive(true);
                }
                else
                {
                    gameWonPanel.SetActive(true);
                    nextLevelBtn.interactable = false;
                }
            }
        }

        ////////////////////
        if (levelNo == 1)
        {
            if (energyNo <= 10)
            {
                progressBarColor.color = Color.red;
                energyText.color = Color.red;
                player.gameObject.transform.localScale = new Vector3(1, 1, 1);
                PlayerController.forwardSpeed = 12;
            }
            if ((energyNo > 10) && (energyNo < 20))
            {
                progressBarColor.color = Color.yellow;
                energyText.color = Color.yellow;
                player.gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                PlayerController.forwardSpeed = 16;
            }
            if (energyNo >= 20)
            {
                progressBarColor.color = Color.green;
                energyText.color = Color.green;
                player.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                PlayerController.forwardSpeed = 20;
            }
            if ((energyNo <= 20) && (energyNo>0)) {
                float e = energyNo;
                float val=e/20f;
                progressBar.value = val;
            }
            else if (energyNo <= 0)
            {
                progressBar.value = 0;
            }
            else {
                progressBar.value = 1;
            }
        }

        if (levelNo == 2)
        {
            if (energyNo <= 12)
            {
                progressBarColor.color = Color.red;
                energyText.color = Color.red;
                player.gameObject.transform.localScale = new Vector3(1, 1, 1);
                PlayerController.forwardSpeed = 14;
            }
            if ((energyNo > 12) && (energyNo < 25))
            {
                progressBarColor.color = Color.yellow;
                energyText.color = Color.yellow;
                player.gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                PlayerController.forwardSpeed = 18;
            }
            if (energyNo >= 25)
            {
                progressBarColor.color = Color.green;
                energyText.color = Color.green;
                player.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                PlayerController.forwardSpeed = 22;
            }
            if ((energyNo <= 25) && (energyNo > 0)) {
                float e = energyNo;
                float val = e / 25f;
                progressBar.value = val;
                progressBar.value = val;
            }
            else if (energyNo <= 0)
            {
                progressBar.value = 0;
            }
            else
            {
                progressBar.value = 1;
            }
        }
        if (levelNo == 3)
        {
            if (energyNo <= 15)
            {
                progressBarColor.color = Color.red;
                energyText.color = Color.red;
                player.gameObject.transform.localScale = new Vector3(1, 1, 1);
                PlayerController.forwardSpeed = 20;
                
            }
            if ((energyNo > 15) && (energyNo < 30))
            {
                progressBarColor.color = Color.yellow;
                energyText.color = Color.yellow;
                player.gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                PlayerController.forwardSpeed = 25;
            }
            if (energyNo >= 30)
            {
                progressBarColor.color = Color.green;
                energyText.color = Color.green;
                player.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                PlayerController.forwardSpeed = 30;
            }

            if ((energyNo <= 30) && (energyNo > 0)) {
                float e = energyNo;
                float val = e / 30f;
                progressBar.value = val;
            }
            else if (energyNo <= 0)
            {
                progressBar.value = 0;
            }
            else
            {
                progressBar.value = 1;
            }
        }
        energyText.text = "" + energyNo;
        ////////////////////

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
