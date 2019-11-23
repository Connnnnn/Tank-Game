using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    public Tracks trackLeft;
    public Tracks trackRight;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 0.2f;
    float moveDeceleration = 0.20f;
    float moveSpeedMax = 5f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;

    public GameObject hitEffect;

    public static int scoreValue1 = 0;
    public static int scoreValue2 = 0;
    
    //private GameObject Gun = GameObject.Find("TankGun");
    //private GameObject Hull = GameObject.Find("TankHull");
    //private GameObject Tower = GameObject.Find("TankTower");

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //I set up 2 checks
        //The first that operations will run as normal and the input of the user will determine If the Tracks will move and if the tank will move if the main game is the current scene 
        //The second that if the scene is the main menu then the animations of the tanks tracks moving will play constantly, without moving the tank
        if (sceneName == "Game Scene")
        {

            rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
            rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
            if (rotateLeft)
            {
                rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
            }
            else
            {
                rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
            }
            transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

            rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
            rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
            if (rotateRight)
            {
                rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
            }
            else
            {
                rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
            }
            transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

            moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
            moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
            if (moveForward)
            {
                moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
            }
            else
            {
                moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
            }
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

            moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
            moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
            if (moveReverse)
            {
                moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
            }
            else
            {
                moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
            }
            transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

            if (moveForward | moveReverse | rotateRight | rotateLeft)
            {
                trackStart();
            }
            else
            {
                trackStop();
            }
        }
        
        else if (sceneName == "Main Menu") {
            trackLeft.animator.SetBool("isMoving", true);
            trackRight.animator.SetBool("isMoving", true);
        }
    }

    void trackStart()
    {
        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
    }

    void trackStop()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
    }


    public void Destroy()
    {

        Debug.Log(this.gameObject + " has died");
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 10f);
        Destroy(this.gameObject);

        GameObject SC = GameObject.Find("ScoreCanvas");
        Score s = SC.GetComponent<Score>();

        if (this.gameObject.name.Contains("Tank Player 1"))
        {
            Debug.Log("Player Two wins!");
            s.PlayerTwoScored();
        }
        if (this.gameObject.name.Contains("Tank Player 2"))
        {
            Debug.Log("Player One wins!");
            s.PlayerOneScored();

        }
        if (s.GameIsOver == false)
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }
}
