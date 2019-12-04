using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject hitEffect;

    //Used to check if it hits the tank to play the tank explosion clip and send us to Tanks destroy method
    //Else, it hits a wall and the regular effect is played
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Tank"))
        {
            Debug.Log("HIT " + collision.gameObject.name);

            FindObjectOfType<AudioManager>().Play("Player Death");

            Tank tank = collision.gameObject.GetComponent<Tank>();
            tank.Destroy();

        }
        else {
            FindObjectOfType<AudioManager>().Play("Wall Hit");
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);

        }
        Destroy(gameObject);
    }
}
