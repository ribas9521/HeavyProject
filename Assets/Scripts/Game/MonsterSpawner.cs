using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour {    
    SpawnerController spawnerController;
    public bool start;
	
	
    public void pseudoAwake(List<GameObject>spawnables, float timer, int quantity)
    {
        spawnerController = GetComponent<SpawnerController>();
        StartCoroutine(spawnerController.Spawn(spawnables, timer, quantity, transform.position));
    }
	
}
