using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject levelTextPanel;

    string sceneToLoad;
    int sceneIndex;

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
        if (anim)
        {
            sceneToLoad = sceneName;
            anim.SetTrigger("loadScene");
        }
        
    }
    public void LoadScene(int index)
    {
        if (anim)
        {
            sceneIndex = index;
            sceneToLoad = "";
            anim.SetTrigger("loadScene");
        }
        
    }
    public void LoadNextScene()
    {
        int nextSceneIndex = 1 + SceneManager.GetActiveScene().buildIndex;
        LoadScene(nextSceneIndex);
    }
    public void LoadSelectedScene()
    {
        if (sceneToLoad != "")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
    }
    public void EnableLevelText()
    {
        if (levelTextPanel)
        {
            levelTextPanel.SetActive(true);
            Invoke("DisableLevelText", 2f);
        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void DisableLevelText()
    {
        levelTextPanel.SetActive(false);
    }
}
