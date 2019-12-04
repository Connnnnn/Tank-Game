using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static int scoreLimit;
    public TMPro.TMP_Dropdown dropdown;
    public GameObject pauseMenuUI;

    //The mid game pause menu which is used to freeze time and either resume, go to menu, or quit
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    //WIP - changing the score limit from the pause menu - will not work if someone has passed that score
    public void getScoreFromDropDown()
    {
        Debug.Log("First to " + dropdown.captionText.text + " selected!");
        string dd = dropdown.captionText.text;
        int newScore = int.Parse(dd);
        scoreLimit = newScore;
        ChangeScoreLimit(scoreLimit);
    }
    public void ChangeScoreLimit(int scoreLimit)
    {
        PlayerPrefs.SetInt("ScoreLimit", scoreLimit);
    }



    public void Resume() {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
