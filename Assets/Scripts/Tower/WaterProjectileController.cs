using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectileController : MonoBehaviour {
    WaterTowerController wc;
    ArrowController ac;
    public GameObject splashFX;
    // Use this for initialization
    void Awake () {
       
        ac = GetComponent<ArrowController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        GetComponentInParent<WaterTowerController>().freeze(ac.nearEnemy);
        Instantiate(splashFX, transform.position, Quaternion.identity);
     
    }
}
