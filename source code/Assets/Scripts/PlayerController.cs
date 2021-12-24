using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float forwardSpeed;
    private CharacterController controller;
    private Vector3 direction;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public float jumpForce;
    public float gravity = -20;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        direction.z = forwardSpeed;

        if (SwipeManager.swipeUp)
        {
            if (controller.isGrounded)
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown)
        {
            if (!controller.isGrounded)
            {
                direction.y = direction.y-jumpForce;
            }

        }


        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;
        //transform.position = Vector3.Lerp(transform.position,targetPosition,150*Time.deltaTime);
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        controller.Move(direction * Time.deltaTime);

    }


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
        {
            if (PlayerManager.energyNo <= 0)
            {
                FindObjectOfType<AudioManager>().playSound("OhNo");
                PlayerManager.gameOver = true;
            }
            else
            {
                Destroy(hit.transform.gameObject);
                direction.y = jumpForce;
                FindObjectOfType<AudioManager>().playSound("ouch");
                PlayerManager.energyNo = PlayerManager.energyNo - 2;
            }
        }

        if (hit.transform.tag == "Finish")
        {

            if (PlayerManager.levelNo == 1)
            {
                if (PlayerManager.energyNo < 20)
                {
                    FindObjectOfType<AudioManager>().playSound("gameOver");
                }
                else
                {
                    FindObjectOfType<AudioManager>().playSound("OhYes");
                    FindObjectOfType<AudioManager>().playSound("youWon");
                }
            }

            if (PlayerManager.levelNo == 2)
            {
                if (PlayerManager.energyNo < 25)
                {
                    FindObjectOfType<AudioManager>().playSound("gameOver");
                }
                else
                {
                    FindObjectOfType<AudioManager>().playSound("OhYes");
                    FindObjectOfType<AudioManager>().playSound("youWon");
                }
            }

            if (PlayerManager.levelNo == 3)
            {
                if (PlayerManager.energyNo < 30)
                {
                    FindObjectOfType<AudioManager>().playSound("gameOver");
                }
                else
                {
                    FindObjectOfType<AudioManager>().playSound("OhYes");
                    FindObjectOfType<AudioManager>().playSound("youWon");
                }
            }
            PlayerManager.gameOver = true;
        }


    }
}
