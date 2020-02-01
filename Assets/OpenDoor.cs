﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void OpenDoors() {
        anim.SetBool("openDoor", true);
    }
}