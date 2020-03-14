using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SelectPlayer(int number)
    {
        PlayerPrefs.SetInt("PlayerChar", number);
        FindObjectOfType<LevelManager>().LoadNextScene();
    }
}
