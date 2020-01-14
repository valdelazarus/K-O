using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    string sceneToLoad;

    Animator anim;

    HealthScript playerHealth; 

    void Start()
    {
        anim = GetComponent<Animator>();
        playerHealth = GameObject.FindWithTag("Player")?.GetComponent<HealthScript>();
    }

    void Update()
    {
        if (playerHealth!= null && playerHealth.characterDied)
        {
            LoadScene("Game Over");
        }
    }
    public void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;    
        anim.SetTrigger("loadScene");
    }
    public void LoadSelectedScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
