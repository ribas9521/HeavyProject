using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusdahoTrigger : MonoBehaviour {
    FusdahoController fc;
	// Use this for initialization
	void Awake () {
        fc = GetComponentInParent<FusdahoController>();
	}
	
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
            fc.collision(other.gameObject);
    }
    
}
