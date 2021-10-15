using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // Particle effect to be used
    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(reward, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
