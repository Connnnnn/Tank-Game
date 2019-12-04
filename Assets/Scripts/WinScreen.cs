using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI winner;
    public GameObject winScreenUI;

    /// <summary>
    /// The win screen is called if a winner bool value is set in the score script
    /// It slows time down, loads the canvas and sets the texts colour and contents depending on the winner
    /// </summary>

    void Update()
    {
        GameObject SC = GameObject.Find("ScoreCanvas");
        Score s = SC.GetComponent<Score>();

        if (s.GameIsOver) {
            Time.timeScale = 0.2f;
            
            winScreenUI.SetActive(true);
            if (s.P1Win) {
                P1Winner();
                
            }
            if (s.P2Win) { 
                P2Winner();
            }
        }
    }
   
    public void P1Winner() {
        
        winner.text = "PLAYER 1 WINS";
        winner.color = new Color32(0, 201, 0, 255);
    }
    public void P2Winner()
    {
        winner.text = "PLAYER 2 WINS";
        winner.color = new Color32(255, 37, 6, 255);
    }
    public void PlayAgain()
    {
        GameObject SC = GameObject.Find("ScoreCanvas");
        Score s = SC.GetComponent<Score>();
        s.GameIsOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
