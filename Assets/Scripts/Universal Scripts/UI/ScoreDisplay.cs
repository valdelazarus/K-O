using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    int score;

    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", 0);
        }

        scoreText.text = "Score: " + score;
    }

    
    void Update()
    {
        
    }
}
