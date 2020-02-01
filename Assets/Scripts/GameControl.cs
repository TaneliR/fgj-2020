using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    public Image oilBar;
    // Start is called before the first frame update

    public void IncreaseScore(int increase)
    {
        score += increase;
        scoreText.text = "Score: " + score;
    }
    public void SetOilBar(float amount) {
        oilBar.fillAmount = amount / 100f;
    }
}

