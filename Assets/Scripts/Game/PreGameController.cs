﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreGameController : MonoBehaviour {
    

    // Use this for initialization
    void Awake () {        

    }
   
    public void newGame()
    {
        SceneManager.LoadScene("CharacterEditor");
    }
    public void continueGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    
  
}
