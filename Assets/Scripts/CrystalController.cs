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
        healthBar = Instantiate(slider) as GameObject;
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
        healthBar.transform.SetParent(GameObject.Find("Canvas").transform);
        healthBar.GetComponent<Slider>().maxValue = status.maxHPoints;
        healthBar.GetComponent<Slider>().value = status.hPoints;
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 newPos = new Vector3(wantedPos.x + 5, wantedPos.y + 35f, wantedPos.z);
        healthBar.transform.position = newPos;
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

}
