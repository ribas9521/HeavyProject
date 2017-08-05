using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    SpawnerController[] spawnerControllers;
    GameObject spawners;
    TouchController touchController;
    Canvas canvas;
    Text text;
    Text victoryGold;
    Text goldResult;
    public int gold;
    public int gems;
    StatusController crystalStatus;
    bool victory = false;
    GameObject gem0, gem1, gem2;
    public Sprite gemFull, gemEmpty;
    public bool startGame = false;
    public bool gameOver;
    GameObject crystal;
    public GameObject CrystalPrefab;
    GameObject skill;
    public int level;
    
    
    

    void Awake () {
        canvas = GameObject.FindObjectOfType<Canvas>();
        text = canvas.transform.Find("Gold").GetComponent<Text>();
        spawners = GameObject.Find("Spawners");        
        skill = GameObject.Find("Skill");
        crystal = GameObject.Find("Crystal");
        crystalStatus = crystal.GetComponent<StatusController>();
        touchController = GetComponent<TouchController>();
        level = 1;

    }

    public void pseudoAwake()
    {
        startGame = true;        
        spawnerControllers = spawners.GetComponentsInChildren<SpawnerController>();
        
        victory = false;
        gems = 1;
        gameOver = false;
    }


   
	// Update is called once per frame
	void Update () {
        if (startGame == true)
        {
            LastHit();
            IsOver();
            Victory();
            
        }
    }
    /*This function returns true if all the variables isOver on the Spawners are true*/
    bool IsOver()
    {
        bool comparator = false;      
         
        foreach (SpawnerController spawnerController in spawnerControllers)
        {
            comparator = true && spawnerController.isOver;
        }
        
        return comparator;
    }

    public void reactiveSpawners()
    {
        foreach (SpawnerController spawnerController in spawnerControllers)
        {
            spawnerController.isOver = false;
        }
    }

    public void UpdateScore(int amount)
    {
        
        if (text != null)
        {
            gold += amount;
            text.text = "Gold: " + gold.ToString();
            
        }
    }
    public void setGold(int amount)
    {
        if (text != null)
        {
            gold = amount;
            text.text = "Gold: " + gold.ToString();

        }

    }

    void LastHit()
    {
        List<RaycastHit2D> touched = touchController.TouchedGO("Monster");
        if (touched != null)
        {
            foreach (RaycastHit2D hit in touched)
            {
               
                    hit.transform.GetComponent<MonsterMovement>().touchKill();
                
            }
        }
    }

    public GameObject[] GetAllMonsters()
    {
        GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster");
        return allMonsters;
    }

    public void DestroyScene()
    {
        GameObject[] allMonsters = GetAllMonsters();
        if (allMonsters.Length > 0 && allMonsters != null)
        {
            foreach (GameObject monster in allMonsters)
            {
                Destroy(monster);
            }
        }        
        Destroy(crystal);
        spawners.SetActive(false);
        canvas.transform.Find("Skill").gameObject.SetActive(false);
        text.text = "";
        skill.SetActive(false);

    }

    public void buildScene()
    {        
        canvas.transform.Find("VictoryScreen2").gameObject.SetActive(false);
        crystal = Instantiate(CrystalPrefab, new Vector2(-6.41f, 0.192f), Quaternion.identity);
        crystalStatus = crystal.GetComponent<StatusController>();
        crystalStatus.hPoints = crystalStatus.maxHPoints;
        crystal.name = "Crystal";
        text.text = "Gold: " + gold;
        skill.SetActive(true);
        reactiveSpawners();        
        
    }
    public void gemCalc(float maxLife, float cLife)
    {           
        if (cLife >= maxLife * 0.8f)
        {
            gems = 3;
            
        }
        else if (cLife >= maxLife * 0.6f)
        {
            gems = 2;
        }
        else
        {
            gems = 1;
        }
        
    }
    public void setGems(int gems, string screen)
    {
        gem0 = canvas.transform.Find(screen).transform
            .Find("Gem0").gameObject;
        gem1 = canvas.transform.Find(screen).transform
           .Find("Gem1").gameObject;
        gem2 = canvas.transform.Find(screen).transform
           .Find("Gem2").gameObject;
        if(gems == 1)
        {
            gem1.GetComponent<Image>().sprite = gemFull;
            gem0.GetComponent<Image>().sprite = gemEmpty;
            gem2.GetComponent<Image>().sprite = gemEmpty;
        }
        else if (gems == 2)
        {
            gem1.GetComponent<Image>().sprite = gemFull;
            gem0.GetComponent<Image>().sprite = gemFull;
            gem2.GetComponent<Image>().sprite = gemEmpty;
        }
        else
        {
            gem1.GetComponent<Image>().sprite = gemFull;
            gem0.GetComponent<Image>().sprite = gemFull;
            gem2.GetComponent<Image>().sprite = gemFull;
        }
    }

    public void GameOver()
    {

        gameOver = true;
        DestroyScene();
        canvas.transform.Find("DeathScreen").gameObject.SetActive(true);       

    }
    public void Victory()
    {   
        if (IsOver() && GetAllMonsters().Length <= 0 && victory == false && gameOver == false)
        {            
            gemCalc(crystalStatus.maxHPoints, crystalStatus.hPoints);
            DestroyScene();
            canvas.transform.Find("VictoryScreen").gameObject.SetActive(true);
            setGems(gems, "VictoryScreen");            
            victory = true;
            level++;
        }
    }
    public void NextVictoryScreen()
    {
        canvas.transform.Find("VictoryScreen2").gameObject.SetActive(true);
        canvas.transform.Find("VictoryScreen").gameObject.SetActive(false);      
        setGems(gems, "VictoryScreen2");
        SetVictoryGold();
        SetGoldResult();
        

    }

    public void SetGoldResult()
    {
        goldResult = canvas.transform.Find("VictoryScreen2").transform
            .Find("GoldResult").GetComponent<Text>();
        goldResult.text = "=  " + (gold * gems).ToString();
        setGold(gold * gems);
        
    }
    public void SetVictoryGold()
    {
        victoryGold = canvas.transform.Find("VictoryScreen2").transform
            .Find("VictoryGold").GetComponent<Text>();
        victoryGold.text = gold + "  X ";
    }
}
