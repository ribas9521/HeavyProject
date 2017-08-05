using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void placeTower(string area, GameObject tower)
    {
        GameObject areaGo = transform.Find(area).gameObject;
        Instantiate(tower, areaGo.transform.position, Quaternion.identity);
    }
}
