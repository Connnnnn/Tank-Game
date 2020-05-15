using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentMenu : MonoBehaviour
{
    public static int numPlayers;
    public TMPro.TMP_Dropdown PlayerDropdown;
    public GameObject ThreeP;
    public GameObject FourP;
    private bool P3 = false;
    private bool P4 = false;

    public TMPro.TMP_InputField ThreePlayerOne;
    public TMPro.TMP_InputField ThreePlayerTwo;
    public TMPro.TMP_InputField ThreePlayerThree;

    public TMPro.TMP_InputField FourPlayerOne;
    public TMPro.TMP_InputField FourPlayerTwo;
    public TMPro.TMP_InputField FourPlayerThree;
    public TMPro.TMP_InputField FourPlayerFour;

    public ParticleSystem TourParticleSystem;

    public GameObject P31Invalid;
    public GameObject P32Invalid;
    public GameObject P33Invalid;

    public GameObject P41Invalid;
    public GameObject P42Invalid;
    public GameObject P43Invalid;
    public GameObject P44Invalid;

    public void Start()
    {
        TourParticleSystem.gameObject.SetActive(true);
    }
    public void ChangePlayerNum(int numPlayers)
    {
        //Debug.Log("Player Num Selected");
        PlayerPrefs.SetInt("NumPlayers", numPlayers);
    }

    public void Update()
    {

        if (PlayerDropdown.captionText.text.Contains("3"))
        {
            ThreeP.SetActive(true);
            FourP.SetActive(false);

            if (P3 == false)
            {
                ThreePlayerMode();
            }
        }
        else if (PlayerDropdown.captionText.text.Contains("4"))
        {
            ThreeP.SetActive(false);
            FourP.SetActive(true);

            if (P4 == false)
            {
                FourPlayerMode();
            }
        }
        else {
            ThreeP.SetActive(false);
            FourP.SetActive(false);
            P3 = false;
            P4 = false;
        }
    }

    public void ThreePlayerMode()
    {
        P3 = true;
        P4 = false;
        Debug.Log("3 Player Selected");

        numPlayers = 3;
        ChangePlayerNum(numPlayers);
        //Debug.Log(PlayerPrefs.GetInt("NumPlayers", 0));
    }

    public void FourPlayerMode()
    {
        P4 = true;
        P3 = false;
        Debug.Log("4 Player Selected");

        numPlayers = 4;
        ChangePlayerNum(numPlayers);
        //Debug.Log(PlayerPrefs.GetInt("NumPlayers", 0));
    }


    public void PlayerNameCheck() {

        //3 PLAYER MODE
        if (P3 == true) {
            //PLAYER 3-1 CHECK
            if (string.IsNullOrEmpty(ThreePlayerOne.text))
            {
                Debug.Log("P1 IS NULL");
                P31Invalid.SetActive(true);
            }
            else
            {
                P31Invalid.SetActive(false);
            }

            //PLAYER 3-2 CHECK
            if (string.IsNullOrEmpty(ThreePlayerTwo.text))
            {
                Debug.Log("P2 IS NULL");
                P32Invalid.SetActive(true);
            }
            else
            {
                P32Invalid.SetActive(false);
            }

            //PLAYER 3-3 CHECK
            if (string.IsNullOrEmpty(ThreePlayerThree.text))
            {
                Debug.Log("P3 IS NULL");
                P33Invalid.SetActive(true);
            }
            else
            {
                P33Invalid.SetActive(false);
            }

           //ALL PLAYERS CORRECT
            if (!string.IsNullOrEmpty(ThreePlayerOne.text) && !string.IsNullOrEmpty(ThreePlayerTwo.text) && !string.IsNullOrEmpty(ThreePlayerThree.text))
            {
                Debug.Log("ISNT NULL");
                P31Invalid.SetActive(false);
                P32Invalid.SetActive(false);
                P33Invalid.SetActive(false);

                //Saving Names to PlayerPrefs
                PlayerPrefs.SetString("Name31", ThreePlayerOne.text);
                PlayerPrefs.SetString("Name32", ThreePlayerTwo.text);
                PlayerPrefs.SetString("Name33", ThreePlayerThree.text);
                Debug.Log("Names set to - "+ PlayerPrefs.GetString("Name31", "No Name")+ ", " +PlayerPrefs.GetString("Name32", "No Name")+ "& "+ PlayerPrefs.GetString("Name33", "No Name"));


                //PROCEED TO NEXT WINDOW FOR 3 PLAYER


            }


        }

        // 4 PLAYER MODE
        else if (P4 == true)
        {
            //PLAYER 4-1 CHECK
            if (string.IsNullOrEmpty(FourPlayerOne.text))
            {
                Debug.Log("P1 IS NULL");
                P41Invalid.SetActive(true);
            }
            else
            {
                P41Invalid.SetActive(false);
            }

            //PLAYER 4-2 CHECK
            if (string.IsNullOrEmpty(FourPlayerTwo.text))
            {
                Debug.Log("P2 IS NULL");
                P42Invalid.SetActive(true);
            }
            else
            {
                P42Invalid.SetActive(false);
            }

            //PLAYER 4-3 CHECK
            if (string.IsNullOrEmpty(FourPlayerThree.text))
            {
                Debug.Log("P3 IS NULL");
                P43Invalid.SetActive(true);
            }
            else
            {
                P43Invalid.SetActive(false);
            }

            //PLAYER 4-4 CHECK
            if (string.IsNullOrEmpty(FourPlayerFour.text))
            {
                Debug.Log("P4 IS NULL");
                P44Invalid.SetActive(true);
            }
            else
            {
                P44Invalid.SetActive(false);
            }

            //ALL PLAYERS CORRECT
            if (!string.IsNullOrEmpty(FourPlayerOne.text) && !string.IsNullOrEmpty(FourPlayerTwo.text) && !string.IsNullOrEmpty(FourPlayerThree.text) && !string.IsNullOrEmpty(FourPlayerFour.text))
            {
                Debug.Log("ISNT NULL");
                P41Invalid.SetActive(false);
                P42Invalid.SetActive(false);
                P43Invalid.SetActive(false);
                P44Invalid.SetActive(false);

                //Saving Names to PlayerPrefs
                PlayerPrefs.SetString("Name41", FourPlayerOne.text);
                PlayerPrefs.SetString("Name42", FourPlayerTwo.text);
                PlayerPrefs.SetString("Name43", FourPlayerThree.text);
                PlayerPrefs.SetString("Name44", FourPlayerFour.text);
                //PROCEED TO NEXT WINDOW FOR 4 PLAYER
                Debug.Log("Names set to - " + PlayerPrefs.GetString("Name41", "No Name") + ", " + PlayerPrefs.GetString("Name42", "No Name") + ", " + PlayerPrefs.GetString("Name43", "No Name") + "& " + PlayerPrefs.GetString("Name44", "No Name"));

                
            }
        }

    }
}

 