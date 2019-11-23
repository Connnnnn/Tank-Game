using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    
    public Image fillImg1;
    public Image fillImg2;
    float timeAmt1 = 1;
    float time1;
    float timeAmt2 = 1;
    float time2 = 0;

    void Start() { 
        time1 = timeAmt1;
        time2 = timeAmt2;
    }

    public void Update() {

        if (Input.GetKeyDown("space"))
        {
            if (fillImg2 != null)
            {
                Debug.Log("Got to P2 Reload");
                time2 = 0;
                while (time2 < timeAmt2)
                {
                    Debug.Log("TEST");
                    time2 += Time.deltaTime;
                    fillImg2.fillAmount = time2;
                }
                time2 = timeAmt2;
                Debug.Log("TEST COMPLETE");
            }
            else { Debug.Log("Fill Image 2 is null"); }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (fillImg2 != null)
            {
                time2 = 0;
                Debug.Log("Got to P1 Reload");
            while (time1 < timeAmt1)
            {
                time1 += Time.deltaTime;
                fillImg1.fillAmount = time1 / timeAmt1;
            }
            time1 = timeAmt1    ;
        }
        else { Debug.Log("Fill Image 1 is null"); }
    }
    }
}
