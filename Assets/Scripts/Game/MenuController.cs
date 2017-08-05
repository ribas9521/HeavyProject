using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    
    
    ItemsModel items;
    int cost;
    public int inicialGold;
    LevelController lc;

    BuyTowerController btc;
    

    // Use this for initialization
    void Awake () {
        spawners = GameObject.Find("Spawners");
        areaGo = GameObject.Find("AvailableArea");
        tc = GameObject.Find("GameMananger").GetComponent<TouchController>();
        gc = GameObject.Find("GameMananger").GetComponent<GameController>();        
        items = GameObject.Find("GameMananger").GetComponent<ItemsModel>();        
        gc.UpdateScore(inicialGold);
        buyTurnText = GameObject.Find("BuyTurn");
        
        lc = GetComponent<LevelController>();
        btc = GetComponent<BuyTowerController>();

    }
	
	// Update is called once per frame
	
    
   
    

    public void startGame()
    {
        print("start");
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
