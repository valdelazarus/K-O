using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public GameObject[] playerCharacters;

    UIManager uiManager;

    void Awake()
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

        if (PlayerPrefs.HasKey("PlayerChar"))
        {
            int playerIndex = PlayerPrefs.GetInt("PlayerChar");
            playerCharacters[playerIndex].SetActive(true);
        }
        else
        {
            playerCharacters[0].SetActive(true);
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
