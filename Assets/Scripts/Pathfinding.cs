using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{
    public GameObject target;
    public GameObject targetObject;
    public float distance;

   

    public GameObject Find(float viewRange)
    {      
        
        if (target != null || target.layer !=9)
        {
            List<GameObject> targetList = new List<GameObject>();
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, viewRange);
            foreach (Collider2D col in cols)
            {               

                if (col.gameObject.tag == target.tag)
                {
                                    
                    targetList.Add(col.gameObject);
                }               
            }
            
            return Nearest(targetList);            
        }
        else
        {
            print("Pathfinding Error, target is null");
            return null;
        }
    }
    GameObject Nearest(List<GameObject> list)
    {
        if (list != null && list.Count > 0)
        {
            GameObject nearest = list[0];          
            foreach (GameObject item in list)
            {
                if (Vector3.Distance(transform.position, item.transform.position) <
                   Vector3.Distance(transform.position, nearest.transform.position))
                {
                    nearest = item;
                }
            }
            return nearest;

        }
        else
            return null;
    }
}
