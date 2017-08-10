using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CrystalController : MonoBehaviour
{
    GameObject healthBar;
    public GameObject slider;
    StatusController status;
    GameController gameController;
    // Use this for initialization
    void Start()
    {        
        
        status = GetComponent<StatusController>();
        gameController = GameObject.Find("GameMananger").GetComponent<GameController>();      
        
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderControl();
        GameOver();
    }
    void SliderControl()
    {
      GameObject.Find("Canvas").transform.Find("LevelInfo")
            .transform.Find("Content").Find("DefeatAttempts")
            .Find("Attempts").GetComponent<Text>().text = status.hPoints.ToString();
    }

    void TakeDamage()
    {

    }

     void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("Monster"))
        {
            status.hPoints--;
        }
    }

    void OnDestroy()
    {
        Destroy(healthBar);
    }
    private void GameOver()
    {
        if(status.hPoints <= 0)
        gameController.GameOver();
    }
    public void startCrystal(int hp)
    {
        status.maxHPoints = hp;
        status.hPoints = status.maxHPoints;

    }

}
