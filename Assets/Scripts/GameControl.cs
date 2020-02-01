using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    public Image oilBar;
    public OpenDoor door;
    // Start is called before the first frame update

    public void IncreaseScore(int increase)
    {
        score += increase;
        scoreText.text = "Scraps: " + score;
        if (score == 1) {
            door.OpenDoors();
        }
    }
    public void SetOilBar(float amount) {
        oilBar.fillAmount = amount / 100f;
    }
}

