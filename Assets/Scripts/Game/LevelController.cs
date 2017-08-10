using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {   
    int quantNorth, quantSouth;
    float timerNorth, timerSouth;
    public List<GameObject> spawnables;
    MonsterSpawner spawnerNorth; 
    MonsterSpawner spawnerSouth;
    CrystalController cc;
	// Use this for initialization
	void Awake () {
       

    }

    public void startLevel(int level)
    {
        spawnerNorth = GameObject.Find("Spawner-North").GetComponent<MonsterSpawner>();
        spawnerSouth = GameObject.Find("Spawner-South").GetComponent<MonsterSpawner>();
        cc = GameObject.FindGameObjectWithTag("Crystal").GetComponent<CrystalController>();
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
        cc.startCrystal(2);
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
        cc.startCrystal(5);
    }
    public void lv3()
    {
        quantNorth = 6;
        quantSouth = 6;
        timerNorth = 3.5f;
        timerSouth = 3.5f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0] };
        List<GameObject> monsters2 = new List<GameObject> { spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters2, timerSouth, quantSouth);
        cc.startCrystal(5);
    }
    public void lv4()
    {
        quantNorth = 7;
        quantSouth = 6;
        timerNorth = 3f;
        timerSouth = 3f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
        cc.startCrystal(5);
    }
    public void lv5()
    {
        quantNorth = 15;
        quantSouth = 12;
        timerNorth = 2.3f;
        timerSouth = 2.5f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
        cc.startCrystal(5);
    }
    public void lv6()
    {
        quantNorth = 25;
        quantSouth = 20;
        timerNorth = 2;
        timerSouth = 2f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1], spawnables[0] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
        cc.startCrystal(5);
    }
    public void lv7()
    {
        quantNorth = 35;
        quantSouth = 40;
        timerNorth = 1.8f;
        timerSouth = 2.0f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1], spawnables[0] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
        cc.startCrystal(7);
    }
    public void lv8()
    {
        quantNorth = 55;
        quantSouth = 42;
        timerNorth = 1f;
        timerSouth = 1.3f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1], spawnables[0], spawnables[1] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
        cc.startCrystal(7);
    }
    public void lv9()
    {
        quantNorth = 80;
        quantSouth = 70;
        timerNorth = .8f;
        timerSouth = 1f;
        List<GameObject> monsters = new List<GameObject> { spawnables[0], spawnables[1], spawnables[0], spawnables[1], spawnables[0] };
        spawnerNorth.pseudoAwake(monsters, timerNorth, quantNorth);
        spawnerSouth.pseudoAwake(monsters, timerSouth, quantSouth);
        cc.startCrystal(7);
    }
}
