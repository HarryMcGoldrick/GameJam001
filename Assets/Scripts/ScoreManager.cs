using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float currentScore;
    public float scorePerSecond;
    public float currentMultiplier;
    public float baseMultiplier = 1f;
    public float boyMultiplierWeight;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;

    private CenterRing centerRing;
    private float timer = 0f;
    


    void Start()
    {
        centerRing = FindObjectOfType<CenterRing>();
        UpdateScore();
        UpdateMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        if (centerRing.points.Count > 0)
        {
            UpdateMultiplier();

            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer = 0f;
                UpdateScore();
            }
        } else
        {
            // End game
        }


    }

    void UpdateScore()
    {

        currentScore += scorePerSecond * currentMultiplier;
        scoreText.text = ((int)currentScore).ToString();
    }

    void UpdateMultiplier()
    {
        currentMultiplier = centerRing.points.Count * boyMultiplierWeight + baseMultiplier;
        string multiplierString = formatNumber(currentMultiplier);

        if (currentMultiplier > 1)
        {
            // Green
            multiplierText.color = new Color(0.01070392f, 1, 0);
        } else
        {
            // Red
            multiplierText.color = new Color(1, 0.1585162f, 0);
        }

        multiplierText.text = multiplierString + "x";
    }


    string formatNumber(float number)
    {
        string s = string.Format("{0:0.00}", number);
        if (s.EndsWith("00"))
        {
            s = ((int)number).ToString();
        }
        return s;
    }
}
