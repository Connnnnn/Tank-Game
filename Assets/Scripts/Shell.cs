using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject hitEffect;
    private bool hit;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Tank"))
        {
            Debug.Log("HIT " + collision.gameObject.name);

            // FindObjectOfType<AudioManager>().Play("TankExplosion");

            Tank tank = collision.gameObject.GetComponent<Tank>();
            tank.Destroy();
            
        }
        hit = true;
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);

    }
}
