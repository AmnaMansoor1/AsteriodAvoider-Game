using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score = 0f;
    public Text scoreText;
    private bool isAlive = true;

    void Update()
    {
        if (isAlive)
        {
            score += Time.deltaTime;
            if (scoreText != null)
                scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void SaveScoreAndEnd()
    {
        isAlive = false;
        int finalScore = Mathf.FloorToInt(score);
        PlayerPrefs.SetInt("FinalScore", finalScore);
        PlayerPrefs.Save();
    }
}