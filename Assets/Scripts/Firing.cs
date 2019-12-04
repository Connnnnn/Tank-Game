using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject ShellPrefab;
    public string Shoot;
    public float ShellForce = 1f;
    private float lastFiredTime = 0f;

    // The Firing scirpt is used to instantiate the shell at the firing point and apply force whenever the Shoot button is pressed by either player
    //And to ensure it can only be done once per second 
    void Update()
    {
        if (Input.GetButtonDown(Shoot) && lastFiredTime + 1f <= Time.time)
        {
            lastFiredTime = Time.time;
            Fire();
        }
    }

    void Fire()
    {
        string o = this.gameObject.name;
        Debug.Log(o + " fired");
        
        GameObject Shell = Instantiate(ShellPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Shell.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * ShellForce, ForceMode2D.Impulse);

    }
}
