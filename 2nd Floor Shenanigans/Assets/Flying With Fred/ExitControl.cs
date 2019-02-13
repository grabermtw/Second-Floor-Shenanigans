﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GetComponent<FredHighScoresList>().Save();
            Application.Quit();
        }
    }

    public void ReturnMainMenu()
    {
        GetComponent<FredHighScoresList>().Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
