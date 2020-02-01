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
            firstDoors.OpenDoors();
        }
        if (score == secondDoorsAmount) {
            camera.TriggerShake();
            secondDoors.OpenDoors();
        }
        if (score == thirdDoorsAmount) {
            camera.TriggerShake();
            thirdDoors.OpenDoors();
        }
    }
    public void SetOilBar(float amount) {
        oilBar.fillAmount = amount / 100f;
    }
}

