using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text shieldCountText;
    public GameObject bossHealthBar;

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
    public void UpdateShieldCountText(int shieldCount)
    {
        shieldCountText.text = shieldCount.ToString();
    }
    public void ShowBossHealthBar()
    {
        bossHealthBar.SetActive(true);
    }
}
