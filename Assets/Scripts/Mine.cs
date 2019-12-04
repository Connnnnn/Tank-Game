using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Note : this is a WIP and not ready for the demo
public class Mine : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    bool hasExploded;
    public GameObject explosionEffect;
    public float blastRadius =5f ;
    public float force = 700f;

    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded) {
            Explode();
        }

    }

    void Explode() {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders) {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.AddForce(force * transform.up);
                if (nearbyObject.gameObject.name.Contains("Tank"))
                {
                    Tank tank = nearbyObject.gameObject.GetComponent<Tank>();
                    tank.Destroy();

                }
            }
        
        }
        Destroy(gameObject);
        Destroy(explosionEffect, 1f);
    }

}
