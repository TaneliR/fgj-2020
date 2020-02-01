﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    public float oilAmount = 100f;
    public bool godMode;

    public GameControl gameControl;
    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        gameControl.SetOilBar(oilAmount);
        oilAmount -= 0.01f;
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        anim.SetBool("isMoving", false);
        // Forward
        if (Input.GetKey("i") && Input.GetKey("o") || Input.GetAxis("Left Stick") <= -0.8f && Input.GetAxis("Right Stick") <= -0.8f){
            anim.SetBool("isMoving", true);
            transform.Translate(moveSpeed * Vector3.up * Time.fixedDeltaTime);
        }
        // Back
        if (Input.GetKey("k") && Input.GetKey("l") || Input.GetAxis("Left Stick") >= 0.8f && Input.GetAxis("Right Stick") >= 0.8f){
            anim.SetBool("isMoving", true);
            transform.Translate(moveSpeed * Vector3.down * Time.fixedDeltaTime);
        }
        if (Input.GetKey("k") && Input.GetKey("o") || Input.GetAxis("Left Stick") >= 0.8f && Input.GetAxis("Right Stick") <= -0.8f){
            anim.SetBool("isMoving", true);
            transform.Rotate(new Vector3(0,0,1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("i") && Input.GetKey("l") || Input.GetAxis("Left Stick") <= -0.8f && Input.GetAxis("Right Stick") >= 0.8f){
            anim.SetBool("isMoving", true);
            transform.Rotate(new Vector3(0,0,-1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("i") || Input.GetAxis("Left Stick") <= -0.8f) {
            anim.SetBool("isMoving", true);
            transform.Translate(moveSpeed * Vector3.up * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(0,0,1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("o") || Input.GetAxis("Right Stick") <= -0.8f) {
            anim.SetBool("isMoving", true);
            transform.Translate(moveSpeed * Vector3.up * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(0,0,-1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("k") || Input.GetAxis("Left Stick") >= 0.8f) {
            anim.SetBool("isMoving", true);
            transform.Translate(moveSpeed * Vector3.down * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(0,0,-1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("l") || Input.GetAxis("Right Stick") >= 0.8f) {
            anim.SetBool("isMoving", true);
            transform.Translate(moveSpeed * Vector3.down * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(0,0,1 * rotationSpeed * Time.fixedDeltaTime));
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "scrap") {
            Destroy (col.gameObject);
            gameControl.IncreaseScore(1);
        }
        else if (col.gameObject.tag == "marko"){
            Loader.Load(Loader.Scene.WinScene);
        }
        else if (col.gameObject.tag == "enemy" && !godMode){
            Loader.Load(Loader.Scene.LoseScene);
        }
    }
}
