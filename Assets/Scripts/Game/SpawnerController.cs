using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour {
    public bool isOver = false;
    
	public IEnumerator Spawn(List<GameObject> spawnables, float timer, int quantity, Vector3 position)
    {
        
        
        foreach(GameObject monster in spawnables) {
            
            for(int i =0; i < quantity; i++) { 

                GameObject monsterClone = (GameObject)Instantiate(monster, position, Quaternion.identity);
               
                
                    
                yield return new WaitForSeconds(timer);

            }
        }
        isOver = true;

    }

    public GameObject Spawn(GameObject spawnable, Vector3 position)
    {
       GameObject spawned = (GameObject)Instantiate(spawnable, position, Quaternion.identity);
       return spawned;
    }
}
