using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWaveController : MonoBehaviour {

    public float speed;
    public float stunTime;
    public float damage;
    float timer;
    float rotationY;
    float rotationZ;
    DamageController damageController;
    // Use this for initialization
    private void Awake()
    {
        damageController = GetComponent<DamageController>();
    }

    void Update ()
    {
        Movement();
        Death();
        timer += Time.deltaTime;

	}
    void Movement()
    {
        rotationY = transform.rotation.y;
        
        
        if (rotationY == 1)
        {
           
            transform.position += (Vector3.left) * speed;
        }
        if (rotationY ==0)

        {            
            transform.position += (Vector3.right) * speed;
        }
        
    } 
    void Death()
    {
        if(timer > 3.5f)
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject != null && col.tag == "Monster")
        {
           col.gameObject.GetComponent<MonsterMovement>().Stun(stunTime);
           damageController.TakeDamage(col.gameObject, 0, damage, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                                 
        }
    }
  
}
