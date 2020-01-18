using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
