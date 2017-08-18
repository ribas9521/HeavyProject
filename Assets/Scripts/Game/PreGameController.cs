using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreGameController : MonoBehaviour {
    

    // Use this for initialization
    void Awake () {        

    }
   
    public void newGame()
    {
        PlayerPrefs.SetFloat("str",0);
        PlayerPrefs.SetFloat("agi", 0);
        PlayerPrefs.SetFloat("inte", 0);
        PlayerPrefs.SetFloat("dex", 0);
        PlayerPrefs.SetInt("Points", 5);
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
