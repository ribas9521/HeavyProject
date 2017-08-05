using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerController : MonoBehaviour {
    ModificatorController mc;
    DamageController dc;
    public GameObject iceFx;    
    public float duration, slowPercentage, slowChance;
    // Use this for initialization
    void Awake () {
        mc = GetComponent<ModificatorController>();
        dc = GetComponent<DamageController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void freeze(GameObject monster)
    {
        mc.slow(monster, iceFx, duration, slowPercentage, slowChance, dc);
    }
}
