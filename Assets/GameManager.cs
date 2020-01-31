using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public GUIText scoreText;
    // Start is called before the first frame update

    public void IncreaseScore(int increase)
    {
        score += increase;
        scoreText.text = "Score: " + score;
    }
}
