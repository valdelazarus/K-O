using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    private Image health_UI;
    public bool isBoss;

    void Start()
    {
        if (!isBoss)
        {
            health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
        }
        else
        {
            FindObjectOfType<UIManager>().ShowBossHealthBar();
            health_UI = GameObject.FindWithTag(Tags.BOSS_HEALTH_UI).GetComponent<Image>();
        }
    }

    public void DisplayHealth(float value, float maxValue) {

        value /= maxValue;

        if (value < 0f)
            value = 0f;

        if (health_UI)
            health_UI.fillAmount = value;

        Debug.Log("Current health bar fill amount: " + value);
    }

    public void DisplayHealthUsingScale(float value, float maxValue)
    {
        value /= maxValue;

        if (value < 0f)
            value = 0f;

        if (health_UI)
        {
            health_UI.GetComponent<RectTransform>().localScale = new Vector3(value, 1f, 1f);
        }

        Debug.Log("Current boss health bar fill amount: " + value);
    } 

} 

































