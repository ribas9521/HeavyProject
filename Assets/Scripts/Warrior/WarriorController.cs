using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour {

    public GameObject powerWave;
    public float powerWaveCooldown;
    float powerWaveTimer =10f;
    GameObject cannon;
    Animator anim;

    private void Awake()
    {
        cannon = transform.Find("Cannon").gameObject;
        anim = GetComponentInChildren<Animator>();
    }    
	
	// Update is called once per frame
	void Update () {
        powerWaveTimer += Time.deltaTime;
	}

    IEnumerator PowerWaveRoutine()
    {
        yield return new WaitForSecondsRealtime(.4f);
       
        if (cannon.transform.localPosition.x == 0.7f)
        {            
            Instantiate(powerWave, cannon.transform.position, Quaternion.Euler(0f, 0, -90f));
        }
        else if (cannon.transform.localPosition.x == -0.7f)
        {
           
            Instantiate(powerWave, cannon.transform.position, Quaternion.Euler(0f, 0f, 90f));
        }
      
    }

    public void PowerWave()
    {
        if (powerWaveTimer >= powerWaveCooldown)
        {
            powerWaveTimer = 0;
            anim.SetTrigger("Attack");
            StartCoroutine(PowerWaveRoutine());
        }
        else
            print("PowerWave on cooldown");

        
    }
}
