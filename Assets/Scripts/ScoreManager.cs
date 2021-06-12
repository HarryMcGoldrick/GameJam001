using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float currentScore;
    public float scorePerSecond;
    public float currentMultiplier;

    private float timer = 0f;

    public TextMeshProUGUI scoreText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        currentScore += scorePerSecond * currentMultiplier;
        scoreText.text = currentScore.ToString();
    }
}
