using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Main menu script for starting game
    public void Play1v1Game()
    {
        Debug.Log("Play!");
        Time.timeScale = 1f;
        //int index = Random.Range(1, 4);
        //SceneManager.LoadScene(index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    
}
