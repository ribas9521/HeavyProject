using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public float str;
    public float agi;
    public float inte;
    public float dex;
    public int points;
    StatusController sc;
    MovementController mc;
	// Use this for initialization
	void Awake () {
        sc = GetComponent<StatusController>();
        mc = GetComponent<MovementController>();
        str =  PlayerPrefs.GetFloat("str");
        agi = PlayerPrefs.GetFloat("agi");
        inte = PlayerPrefs.GetFloat("inte");
        dex = PlayerPrefs.GetFloat("dex");
        sc.str = str;
        sc.agi = agi;
        sc.inte = inte;
        sc.dex = dex;
        points = PlayerPrefs.GetInt("Points");
        updateStatus();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateBdStatus(){
        PlayerPrefs.SetFloat("str", sc.str);
        PlayerPrefs.SetFloat("agi", sc.agi);
        PlayerPrefs.SetFloat("inte", sc.inte);
        PlayerPrefs.SetFloat("dex", sc.dex);
    }
    public void getStatus()
    {
        str = sc.str;
        agi = sc.agi;
        inte = sc.inte;
        dex = sc.dex;
        points = PlayerPrefs.GetInt("Points");
    }
    public void updateStatus()
    {
        getStatus();
        sc.pAttack = str;
        sc.mAttack = inte;
        sc.criticalChance = dex / 10;
        sc.criticalMultiplier = 1 + (str / 10);
        sc.accuracy = dex;
        mc.moveSpeed = 1 + (agi / 10);
        mc.attackSpeed = 1 - (agi / 50);        

    }
    public void closeStatus()
    {

    }
    public void updatePoints(int amount)
    {
        points += amount;
        PlayerPrefs.SetInt("Points", points);
    
    }

}
