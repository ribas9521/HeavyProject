using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerController : MonoBehaviour {

    public GameObject burnFx;
    public int burnPercentage;
    public float burnDamage;
    public float burnDuration;
    public float burnFreq;
    DamageController dc;
    ModificatorController mc;
   
    
	// Use this for initialization
	void Awake () {
        dc = GetComponent<DamageController>();
        mc = GetComponent<ModificatorController>();               
	}
    
    public void burn(GameObject monster)
    {
        mc.burn(monster, burnFx, burnDuration, burnFreq, burnDamage, burnPercentage, dc);
    }    

   
}
