using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollisionCheck : MonoBehaviour
{
    public Patrol patrol;

    public LineRenderer lineOfSight;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            patrol = transform.parent.gameObject.GetComponent<Patrol>();

            patrol.Pause();
            patrol.isChasing = true;
        }

    }

}
