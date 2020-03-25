using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInventory : MonoBehaviour
{
    public AudioClip useShieldSound;

    float shieldDuration;
    int shieldCount;
    UIManager uiManager;
    bool shieldActive = false;

    AudioSource audioSource;
   
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (PlayerPrefs.HasKey("ShieldCount"))
        {
            shieldCount = PlayerPrefs.GetInt("ShieldCount");
        }
        uiManager.UpdateShieldCountText(shieldCount);

        if (GetComponent<AudioSource>())
        {
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponentInChildren<AudioSource>();
        }
    }

    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire3") && !shieldActive)
        {
            UseShield();
        }
    }

    public void AddShield(float duration)
    {
        shieldCount++;
        uiManager.UpdateShieldCountText(shieldCount);
        shieldDuration = duration;
        PlayerPrefs.SetInt("ShieldCount", shieldCount);
    }
    void UseShield()
    {
        if (shieldCount <= 0) return;
        audioSource.PlayOneShot(useShieldSound);
        shieldActive = true;
        shieldCount--;
        uiManager.UpdateShieldCountText(shieldCount);
        PlayerPrefs.SetInt("ShieldCount", shieldCount);
        StopCoroutine(ActivateInvulnerable());
        StartCoroutine(ActivateInvulnerable());
    }

    IEnumerator ActivateInvulnerable()
    {
        GetComponent<HealthScript>().invulnerable = true;
        yield return new WaitForSeconds(shieldDuration);
        GetComponent<HealthScript>().invulnerable = false;
        shieldActive = false;
    }
}
