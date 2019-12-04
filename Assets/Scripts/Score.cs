using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    static int scoreValue1 = 0;
    static int scoreValue2 = 0;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public bool P1Win = false;
    public bool P2Win = false;
    public bool GameIsOver = false;
    public static int WinAmount = 1;

    //I use the Score script to keep track of the score of the 2 enemies and to display this each time a player scores
    //It also is used to check if either player has won

     void Start()
    {
        WinAmount = PlayerPrefs.GetInt("ScoreLimit", 0);
        Debug.Log(WinAmount);
    }
    void Awake()
    {
        score1.text = "Score: " + scoreValue1;
        score2.text = "Score: " + scoreValue2;
    }

    public void PlayerOneScored() {

        if (scoreValue1+1 < WinAmount) {
            scoreValue1++;
            Debug.Log("Player One Scored");
            Debug.Log("P1 Score: " + scoreValue1);
            
            score1.text = "Score: " + scoreValue1;
        }
        else if (scoreValue1+1 >= WinAmount)
        {
            scoreValue1 = 0;
            scoreValue2 = 0;
            P1Win = true;
            GameIsOver = true;
            Debug.Log("P1 won the game");
}
    }

    public void PlayerTwoScored()
    {
        if (scoreValue2+1 < WinAmount)
        {
            scoreValue2++;
            Debug.Log("Player Two Scored");
            Debug.Log("P2 Score: " + scoreValue2);

            score2.text = "Score: " + scoreValue2;
        }
        else if (scoreValue2+1 >= WinAmount)
        {
            scoreValue1 = 0;
            scoreValue2 = 0;
            P2Win = true;
            GameIsOver = true;
            Debug.Log("P2 won the game");
        }
    }
}
