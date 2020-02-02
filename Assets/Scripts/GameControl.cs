﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Image oilBar;
    public OpenDoor firstDoors;
    public OpenDoor secondDoors;
    public OpenDoor thirdDoors;
    public ShakeBehavior camera;
    public AudioClip doorSound;
    public int firstDoorsAmount = 4;
    public int secondDoorsAmount = 8;
    public int thirdDoorsAmount = 12;
    // Start is called before the first frame update

    public void IncreaseScore(int increase)
    {
        score += increase;
        scoreText.text = "Scraps: " + score;
        if (score == firstDoorsAmount) {
            camera.TriggerShake();
            StartCoroutine(OpenAfterWait(1f, firstDoors));
        }
        if (score == secondDoorsAmount) {
            camera.TriggerShake();
            StartCoroutine(OpenAfterWait(1f, secondDoors));
        }
        if (score == thirdDoorsAmount) {
            camera.TriggerShake();
            StartCoroutine(OpenAfterWait(1f, thirdDoors));
        }
    }
    public void SetOilBar(float amount) {
        oilBar.fillAmount = amount / 100f;
    }

    IEnumerator OpenAfterWait(float time, OpenDoor door)
    {
        yield return new WaitForSeconds(time);
        SFXManager.Instance.Play(doorSound);
        door.OpenDoors();
        // Code to execute after the delay
    }
}

