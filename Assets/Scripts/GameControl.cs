using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public int score = 0;
    public int maxScore = 4;
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
        if (score == firstDoorsAmount) {
            maxScore = 11;
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
        scoreText.text = "Scraps:" + score + "/" + maxScore;
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

