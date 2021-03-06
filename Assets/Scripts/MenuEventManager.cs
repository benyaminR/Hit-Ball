﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuEventManager : MonoBehaviour
{
    public Button startButton,settingsButton,exitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(()=>{
            PlayerPrefs.SetInt("score",0);
            PlayerPrefs.SetInt("lvl",1);
            SceneManager.LoadScene("StartScene");
            });
        settingsButton.onClick.AddListener(()=>Debug.Log("Settings!"));
        exitButton.onClick.AddListener(()=>Application.Quit());

    }
    void Update(){

    }
}
