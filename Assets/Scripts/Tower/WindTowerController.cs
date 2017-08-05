using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTowerController : MonoBehaviour {
    MovementController mc;
    public float msUp;
	// Use this for initialization
	void Start () {
        mc = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MovementController>();
        mc.moveSpeed += msUp;
	}
    private void OnDestroy()
    {
        mc.moveSpeed -= msUp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
