using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileController : MonoBehaviour
{    
    DamageController dc;
    ArrowController ac;

    // Use this for initialization
    void Awake()
    {      
        ac = GetComponent<ArrowController>();
    }

    // Update is called once per frame
   
    private void OnDestroy()
    {
        
        GetComponentInParent<FireTowerController>().burn(ac.nearEnemy);
    }

    
}
