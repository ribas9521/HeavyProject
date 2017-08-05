using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TrailRenderer>().sortingLayerName = "Trail";
        GetComponent<TrailRenderer>().sortingOrder = 9;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            transform.position = new Vector3(mouseX, mouseY, 5f);
           
        }
	}
}
