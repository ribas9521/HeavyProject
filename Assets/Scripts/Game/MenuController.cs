using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    public GameObject fireTower, waterTower, windTower, earthTower;
    TouchController tc;
    bool buyTurn = true;
    Vector2 point;
    GameObject area;
    GameObject tower;
    GameController gc;
    GameObject spawners;
    GameObject areaGo;
    GameObject buyTurnText;
    GameObject mainInfo;
    GameObject otherInfo;
    
    
    
    ItemsModel items;
    int cost;
    public int inicialGold;
    LevelController lc;

    BuyTowerController btc;
    bool pause;
    GameObject playButton, pauseButton;
    bool status = false;
    GameObject statusGo;
    public Sprite activeImage, InactiveImage;
    PlayerStatus ps;


    // Use this for initialization
    void Awake () {
        spawners = GameObject.Find("Spawners");
        areaGo = GameObject.Find("AvailableArea");
        tc = GameObject.Find("GameMananger").GetComponent<TouchController>();
        gc = GameObject.Find("GameMananger").GetComponent<GameController>();        
        items = GameObject.Find("GameMananger").GetComponent<ItemsModel>();        
        gc.UpdateScore(inicialGold);
        buyTurnText = GameObject.Find("BuyTurn");
        mainInfo = GameObject.Find("Canvas").transform.Find("LevelInfo").gameObject;
        otherInfo = GameObject.Find("Canvas").transform.Find("OtherInfo").gameObject;
        lc = GetComponent<LevelController>();
        btc = GetComponent<BuyTowerController>();
        pause = false;
        pauseButton = otherInfo.transform.Find("Content").Find("Pause").Find("PauseContent").gameObject;
        playButton = otherInfo.transform.Find("Content").Find("Pause").Find("Play").gameObject;
        statusGo = GameObject.Find("Canvas").transform.Find("Status").gameObject;
        statusGo.SetActive(false);
        playButton.SetActive(false);
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();

    }

    // Update is called once per frame

    public void toggleStatus()
    {
        status = !status;
        if (status)
        {
            statusGo.SetActive(true);
        }
        else
        {
            statusGo.SetActive(false);
        }

    }
    private void Update()
    {
        if(ps.points > 0)
        {
            mainInfo.GetComponentInChildren<Image>().sprite = activeImage;
        }
        else
            mainInfo.GetComponentInChildren<Image>().sprite = InactiveImage;
    }

    public void pauseGame()
    {
        pause = !pause;
        if (pause)
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0.0f;
            
        }
        else
        {
            playButton.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1.0f;
        }
    }

    public void startGame()
    {

        buyTurn = false;
        spawners.SetActive(true);
        gc.pseudoAwake();
        buyTurnText.SetActive(false);
        areaGo.SetActive(false);
        
        lc.startLevel(gc.level);
        
    }
    public void backToStart()
    {
        gc.buildScene();        
        buyTurn = true;       
        areaGo.SetActive(true);
        buyTurnText.SetActive(true);
        btc.getTowers();
        btc.getAreas();

    }
    public void restartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
