﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public string[] sentences;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialogManager>().ShowDialog(sentences);
            Destroy(gameObject);
        }
    }
}
