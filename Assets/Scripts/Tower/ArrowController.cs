using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
    Pathfinding pathfinding;
    DamageController damageController;
    public GameObject nearEnemy;
    public float moveSpeed;
    public float viewRange;
    public float damage;
    Quaternion lookRotation;
    Vector3 direction;
    

    // Use this for initialization
    void Start () {                
     
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();
        nearEnemy = pathfinding.Find(viewRange);
	}
	void Rotate()
    {
        direction = (nearEnemy.transform.position - transform.position).normalized;        
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
	
	void Update () {

        if (nearEnemy != null)
        {
            Rotate();
            GoTo(nearEnemy.transform);
            
            Harm();
            
        }
        else
            SelfDestruction();

	}

    void GoTo(Transform target)
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
       
    }

    public void Harm()
    {
        if (GetDistance(nearEnemy) <= 0.5f)
        {
            if (nearEnemy != null)
            {
                damageController.TakeDamage(nearEnemy, damage, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                SelfDestruction();
            }
        }
       
    }

    public void SelfDestruction()
    {
        Destroy(gameObject);
    }

    float GetDistance(GameObject target)
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }
}
