using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificatorController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void burn(GameObject monster, GameObject prefab, float duration, float freq, float damage, int percentage, DamageController dc)
    {
        float r = Random.Range(0, 100);

        if (monster != null && monster.transform.Find("FX").Find("burnFX") == null && r < percentage)
        {
            GameObject burnFxi = Instantiate(prefab, monster.transform.position, Quaternion.identity);
            burnFxi.transform.SetParent(monster.transform.Find("FX"));
            burnFxi.transform.localPosition = new Vector3(0, 0, 0);
            burnFxi.name = "burnFX";
            StartCoroutine(takeBurnDamage(monster, duration, damage, freq, dc));
            if (burnFxi != null)
                Destroy(burnFxi, duration);


        }
    }
    IEnumerator takeBurnDamage(GameObject monster, float burnDuration, float burnDamage, float freq, DamageController dc)
    {
        for (int x = 0; x < burnDuration; x++)
        {
            if (monster != null)
            {
                dc.TakeDamage(monster, 0, burnDamage, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                yield return new WaitForSeconds(freq);
            }
        }
    }
    public void stun(GameObject monster, GameObject prefab, float duration, float stunChance)
    {
        float r = Random.Range(0, 100);
        if (monster != null && monster.transform.Find("FX").Find("stunFX") == null && r < stunChance)
        {
            GameObject stunFx = Instantiate(prefab, monster.transform.position, Quaternion.identity);
            stunFx.transform.SetParent(monster.transform.Find("FX"));
            stunFx.transform.localPosition = new Vector3(0, 1.3f, 0);
            stunFx.name = "stunFX";
            if (stunFx != null)
                Destroy(stunFx, duration);
            StartCoroutine(takeStun(monster, duration, monster.GetComponent<MonsterMovement>()));
            
        }
    }
    
    IEnumerator takeStun(GameObject monster, float duration, MonsterMovement mv)
    {
        float inicialMv = mv.moveSpeed;
        mv.moveSpeed = 0;
        yield return new WaitForSecondsRealtime(duration);      
        mv.moveSpeed = inicialMv;
    }
    public void slow(GameObject monster, GameObject prefab, float duration, float slowPercentage, float slowChance, DamageController dc)
    {
        float r = Random.Range(0, 100);
        if (monster != null && monster.transform.Find("FX").Find("slowPrefab") == null && r < slowChance)
        {
            GameObject slowFx = Instantiate(prefab, monster.transform.position, Quaternion.identity);
            slowFx.transform.SetParent(monster.transform.Find("FX"));
            slowFx.transform.localPosition = new Vector3(0, 0, 0);
            slowFx.name = "slowPrefab";
            StartCoroutine(takeSlow(monster, duration, slowPercentage, monster.GetComponent<MonsterMovement>()));
            if (slowFx != null)
                Destroy(slowFx, duration);
        }
    }
    IEnumerator takeSlow(GameObject monster, float duration,float slowPercentage, MonsterMovement mv)
    {
        float inicialMv = mv.moveSpeed;
        mv.moveSpeed =mv.moveSpeed - ( mv.moveSpeed * (slowPercentage / 100));
        yield return new WaitForSeconds(duration);
        mv.moveSpeed = inicialMv;
    }
}
