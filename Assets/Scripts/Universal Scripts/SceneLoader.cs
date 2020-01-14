using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string levelToLoad;

    void Start()
    {
                
    }

    
    void Update()
    {
        if (Input.GetButtonDown(Button.FIRE_1))
        {
            FindObjectOfType<LevelManager>().LoadScene(levelToLoad);
        }
    }
}
