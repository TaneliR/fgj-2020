using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int score = 0;
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
            PlayAfterWait(2f);
            firstDoors.OpenDoors();
        }
        if (score == secondDoorsAmount) {
            camera.TriggerShake();
            PlayAfterWait(1f);
            secondDoors.OpenDoors();
        }
        if (score == thirdDoorsAmount) {
            camera.TriggerShake();
            PlayAfterWait(1f);
            thirdDoors.OpenDoors();
        }
    }
    public void SetOilBar(float amount) {
        oilBar.fillAmount = amount / 100f;
    }

    IEnumerator PlayAfterWait(float time)
    {
        yield return new WaitForSeconds(time);
        SFXManager.Instance.Play(doorSound);
        // Code to execute after the delay
    }
}

