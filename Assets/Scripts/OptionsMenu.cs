using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public static int scoreLimit;
    public TMPro.TMP_Dropdown dropdown;

    
    public void getScoreFromDropDown() {
        Debug.Log("First to "+dropdown.captionText.text+ " selected!");
        string dd = dropdown.captionText.text;
        int newScore = int.Parse(dd);
        scoreLimit = newScore;
        ChangeScoreLimit(scoreLimit);
    }
    public void ChangeScoreLimit(int scoreLimit) {

       PlayerPrefs.SetInt("ScoreLimit", scoreLimit);
    }


}
