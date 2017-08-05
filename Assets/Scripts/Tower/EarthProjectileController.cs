using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthProjectileController : MonoBehaviour {
    EarthTowerController ec;
    ArrowController ac;
	// Use this for initialization
	void Awake () {
        ac = GetComponent<ArrowController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        GetComponentInParent<EarthTowerController>().stun(ac.nearEnemy);
    }
}
