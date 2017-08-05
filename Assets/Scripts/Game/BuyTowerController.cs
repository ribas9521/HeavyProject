using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTowerController : MonoBehaviour {

    
    GameObject buyTurn;
    GameObject[] towers = new GameObject[5];
    TouchController tc;
    int index = 0;
    List<GameObject> areas = new List<GameObject>();
    GameObject selectedArea;
    string selectedTower;
    public GameObject TowerDefault, TowerFire, TowerWater, TowerWind, TowerEarth;
    ItemsModel items;
    Animator anim;
    GameController gc;
    public bool isAreaSelected = false;
    public bool lockTower = true;

    void Start () {
        getTowers();
        getAreas();
        tc = GetComponent<TouchController>();
        items = GameObject.Find("GameMananger").GetComponent<ItemsModel>();
        anim =GameObject.Find("BackGround").GetComponent<Animator>();
        gc = GetComponent<GameController>();
    }
	public void getTowers()
    {
        buyTurn = GameObject.Find("BackGround");
        for (int i = 0; i < buyTurn.transform.childCount - 3; i++)
        {
            towers[i] = buyTurn.transform.GetChild(i).gameObject;            
        }
       
    }
    public void getAreas()
    {
        foreach (Transform t in GameObject.Find("AvailableArea").transform)
        {
            areas.Add(t.gameObject);
        }

    }
	// Update is called once per frame
	void Update () {
        if(!isAreaSelected )
            getTouchedArea();
    }
    public void getTouchedArea()
    {
        
        if (tc.TouchedObject() != null && areas.Contains(tc.TouchedObject()))
        {
            selectedArea = tc.TouchedObject();
            isAreaSelected = true;
            anim.SetTrigger("Down");
        }
        
    }

    public void changeTower(int i)
    {       
        index += i;        

        if (i == 1)
        {
            if(index > towers.Length - 1)
            {
                towers[index-1].SetActive(false);
                index = 0;
            }
            towers[index].SetActive(true);
            if(index - 1 >= 0)
                towers[index - 1].SetActive(false);         
           
        }
        if(i == -1)
        {
            if(index < 0)
            {
                towers[0].SetActive(false);
                index = towers.Length -1;
            }
            towers[index].SetActive(true);
            if(index + 1 <= towers.Length -1)
                towers[index +1].SetActive(false);
        }   
    }

    public void chooseTower()
    {      
            
            selectedTower = towers[index].name;

            if (selectedTower == "TowerFire" && gc.gold >= items.fireTower()[0])
            {

                Instantiate(TowerFire, selectedArea.transform.position, Quaternion.identity);
                gc.UpdateScore(-items.fireTower()[0]);
                Destroy(selectedArea);
            }
            if (selectedTower == "TowerWater" && gc.gold >= items.waterTower()[0])
            {

                Instantiate(TowerWater, selectedArea.transform.position, Quaternion.identity);
                gc.UpdateScore(-items.waterTower()[0]);
                Destroy(selectedArea);
            }
            if (selectedTower == "TowerWind" && gc.gold >= items.windTower()[0])
            {

                Instantiate(TowerWind, selectedArea.transform.position, Quaternion.identity);
                gc.UpdateScore(-items.windTower()[0]);
                Destroy(selectedArea);
            }
            if (selectedTower == "TowerEarth" && gc.gold >= items.earthTower()[0])
            {

                Instantiate(TowerEarth, selectedArea.transform.position, Quaternion.identity);
                gc.UpdateScore(-items.earthTower()[0]);
                Destroy(selectedArea);
            }
            if (selectedTower == "TowerDefault" && gc.gold >= items.defaultTower()[0])
            {

                Instantiate(TowerDefault, selectedArea.transform.position, Quaternion.identity);
                gc.UpdateScore(-items.defaultTower()[0]);
                Destroy(selectedArea);
            }
            anim.SetTrigger("Up");
            isAreaSelected = false;
            selectedTower = null;
        
    }
    public void closeTowersWindow()
    {
        anim.SetTrigger("Up");
        isAreaSelected = false;
    }
    
    
}
