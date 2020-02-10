using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        

        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }

        if (uiManager)
        {
            uiManager.UpdateScoreText(score);
        }
    }

    
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        score += value;
        if (uiManager)
        {
            uiManager.UpdateScoreText(score);
        }
        PlayerPrefs.SetInt("Score", score);
    }
}
