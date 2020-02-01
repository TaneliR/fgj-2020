using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollisionCheck : MonoBehaviour
{
    public EnemyFov fov;

    public LineRenderer lineOfSight;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Turpaan!");
            fov.LineCheck();
        }

    }

}
