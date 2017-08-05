using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {   
    int quantNorth, quantSouth;
    float timerNorth, timerSouth;
    public List<GameObject> spawnables;
    MonsterSpawner spawnerNorth; 
    MonsterSpawner spawnerSouth;
	// Use this for initialization
	void Awake () {
       

    }

    public void startLevel(int level)
    {
        spawnerNorth = GameObject.Find("Spawner-North").GetComponent<MonsterSpawner>();
        spawnerSouth = GameObject.Find("Spawner-South").GetComponent<MonsterSpawner>();
        switch (level)
        {
            case 1:
                lv1();
                break;
            case 2:
                lv2();
                break;
            case 3:
                lv3();
                break;
            case 4:
                lv4();
                break;
            case 5:
                lv5();
                break;
            case 6:
                lv6();
                break;
            case 7:
                lv7();
                break;
            default:
                lv1();
                break;
        }

    }

    public void lv1()
    {
        quantNorth = 1;
        quantSouth = 1;
        timerNorth = 5;
        timerSouth = 4.25f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
    }
    public void lv2()
    {
        quantNorth = 1;
        quantSouth = 1;
        timerNorth = 5;
        timerSouth = 4.25f;
        List<GameObject> monsters = new List<GameObject> { spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
    }
    public void lv3()
    {
        quantNorth = 5;
        quantSouth = 5;
        timerNorth = 4;
        timerSouth = 3.8f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0] };
        List<GameObject> monsters2 = new List<GameObject> { spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters2, timerSouth, quantSouth);
    }
    public void lv4()
    {
        quantNorth = 6;
        quantSouth = 5;
        timerNorth = 4;
        timerSouth = 3.6f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
    }
    public void lv5()
    {
        quantNorth = 10;
        quantSouth = 10;
        timerNorth = 3;
        timerSouth = 4f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
    }
    public void lv6()
    {
        quantNorth = 12;
        quantSouth = 12;
        timerNorth = 3;
        timerSouth = 4f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1], spawnables[0] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
    }
    public void lv7()
    {
        quantNorth = 15;
        quantSouth = 15;
        timerNorth = 3;
        timerSouth = 3f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1], spawnables[0] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
    }
}
