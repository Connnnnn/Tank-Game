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
    public Timer timer;
    public GameObject tm;

       void Start()
    {
        timer =tm.GetComponent<Timer>();
        

    }

    void Update()
    {
        if (Input.GetButtonDown(Shoot) && lastFiredTime + 1f <= Time.time)
        {
            lastFiredTime = Time.time;
            Fire();
            //timer.Reload();
        }
    }

    void Fire()
    {
        string o = this.gameObject.name;
        Debug.Log(o);
        
        GameObject Shell = Instantiate(ShellPrefab, FirePoint.position, FirePoint.rotation);
       // Shell.GetOwner(o);
        Rigidbody2D rb = Shell.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * ShellForce, ForceMode2D.Impulse);

    }
}
