using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    int scoreValue1 = 0;
    int scoreValue2 = 0;
    public Text score1;
    public TMP_Text score2;

    public void PlayerOneScored() {
        Debug.Log("Player One Scored");
        score1 = GetComponent<Text>();
        score1.text = "P1 Score: " + scoreValue1;
        
    }

    public void PlayerTwoScored()
    {
        Debug.Log("Player Two Scored");
        score2 = GetComponent<TMP_Text>();
        score2.text = "Score: " + scoreValue2;
    }
}
