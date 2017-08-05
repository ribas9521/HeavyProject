using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTowerController : MonoBehaviour {
    ModificatorController mc;
    DamageController dc;
    public GameObject stunFx;
    public float stunDuration, stunChance;
    // Use this for initialization
    void Start () {
        mc = GetComponent<ModificatorController>();
        dc = GetComponent<DamageController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void stun(GameObject monster)
    {
        mc.stun(monster, stunFx, stunDuration, stunChance);
    }
}
