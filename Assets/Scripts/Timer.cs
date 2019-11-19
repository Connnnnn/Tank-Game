using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    Image fillImg;
    public float timeAmt = 1;
    float time;
    public Text timeText;

    void Start() {
        fillImg = this.GetComponent<Image>();
        time = timeAmt;
    }

    public void Reload() {
        if (time > 0)
        {
            time -= Time.deltaTime;
            fillImg.fillAmount = time / timeAmt;
            timeText.text = "Time : " + time.ToString("F");
        }
        else {
            time = timeAmt;
        }
    }
}
