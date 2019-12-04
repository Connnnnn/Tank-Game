using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    
    public Image fillImg1;
    public Image fillImg2;
    private float timeAmt1 = 1;
    private float time1;
    private float timeAmt2 = 1;
    private float time2 = 0;
    private float lastFiredTime1 = 0f;
    private float lastFiredTime2 = 0f;
    bool doingFill2;
    bool doingFill1;

    //The Timer class is for the Reload amination for the gun
    //Using a check to see if either firing button is pressed, and ensuring that a second has passed, along wih checking the fill isnt ongoing, a coroutine is started 
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !doingFill2 && lastFiredTime2 + 1f <= Time.time)
        {
            StartCoroutine(Fill2Routine());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !doingFill1 && lastFiredTime1 + 1f <= Time.time)
        {
            StartCoroutine(Fill1Routine());
        }
    }

    //I reset the fill value of the Image to 0 and while it it is less than 1 i use deltaTime to fill it 
    IEnumerator Fill2Routine()
    {
        if (doingFill2) yield break;

        time2 = 0;
        fillImg2.fillAmount = 0;
        doingFill2 = true;

        if (!fillImg2)
        {
            Debug.Log("Fill Image 2 is null");
            yield break;
        }

        Debug.Log("Got to P2 Reload");

        while (fillImg2.fillAmount < 1)
        {
            fillImg2.fillAmount = time2 / timeAmt2;
            time2 += Time.deltaTime;
            yield return null;
        }

        doingFill2 = false;
    }

    IEnumerator Fill1Routine()
    {
        if (doingFill1) yield break;

        time1 = 0;
        fillImg1.fillAmount = 0;
        doingFill1 = true;

        if (!fillImg1)
        {
            Debug.Log("Fill Image 1 is null");
            yield break;
        }

        Debug.Log("Got to P1 Reload");

        while (fillImg1.fillAmount < 1)
        {
            fillImg1.fillAmount = time1 / timeAmt1;
            time1 += Time.deltaTime;
            yield return null;
        }

        doingFill1 = false;
    }
}
