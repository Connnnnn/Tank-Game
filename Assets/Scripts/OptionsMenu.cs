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
    private float volume = 1f;
    public Slider vol;

    public void getScoreFromDropDown() {
        Debug.Log("First to " + dropdown.captionText.text + " selected!");
        string dd = dropdown.captionText.text;
        int newScore = int.Parse(dd);
        scoreLimit = newScore;
        ChangeScoreLimit(scoreLimit);
    }
    public void ChangeScoreLimit(int scoreLimit) {

        PlayerPrefs.SetInt("ScoreLimit", scoreLimit);
    }
    public void Awake()
    {
        if (vol != null && PlayerPrefs.HasKey("Volume")){

            float wantedVolume = PlayerPrefs.GetFloat("Volume", 1f);
            vol.value = wantedVolume;

            AudioListener.volume = wantedVolume;

           
            vol.onValueChanged.AddListener(delegate {
                SetGameVolume(vol.value);
            });
        }
    }
    //WIP - Used to set the in game volume from the options menu
    public void SetGameVolume(float volume)
    {
        //AudioListener.volume = volume;
        //PlayerPrefs.SetFloat("volume", volume);
        Debug.Log("Volume set to: "+ volume);
    }
}

