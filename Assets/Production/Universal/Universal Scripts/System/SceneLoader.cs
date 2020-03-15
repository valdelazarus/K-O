using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SceneLoader : MonoBehaviour
{
    public string levelToLoad;

    void Start()
    {
                
    }

    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(Button.FIRE_1))
        {
            FindObjectOfType<LevelManager>().LoadScene(levelToLoad);
        }
    }
}
