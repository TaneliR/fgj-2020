using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    public AudioClip audioclip;
    public bool destroy;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player"))
        {
            SFXManager.Instance.Play(audioclip);
            if (destroy) {
                Destroy(gameObject);
            }
        }
    }

}
