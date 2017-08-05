using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    Animator anim;
    public float moveSpeed;
    public float attackRange;
    public float attackSpeed;
    public float viewRange;
    float attackTimer;
    GameObject cannon;
    


    public GameObject nearEnemie = null;
    float h;
    float v;    
    Pathfinding pathfinding;
    DamageController damageController;
    StatusController status;
  
    TouchController touchController;

    


    float oldX, oldY;
    


 
    void Awake()
    {        
        oldX = (float)System.Math.Round(transform.position.x, 0);
        oldY = (float)System.Math.Round(transform.position.y, 0);
        anim = transform.Find("Dummy").transform.Find("Animation").GetComponent<Animator>();
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();
        status = GetComponent<StatusController>();
     
        touchController = GetComponent<TouchController>();
        cannon = transform.Find("Cannon").gameObject;
    }
   

    // Update is called once per frame
    void Update()
    {      
        attackTimer += Time.deltaTime;        
        MoveDetection();
        manualWalking();
        ClampPosition();
        Return();
        placeCannon();
        automaticMovement();        

    }

    void automaticMovement()
    {
        if (nearEnemie == null)
        {
            nearEnemie = pathfinding.Find(viewRange);

        }
        else
        {
            if (GetDistance(nearEnemie) > attackRange)
            {
                GoTo(nearEnemie.transform);
            }

        }
    }
    

    float GetDistance(GameObject target)
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }
    
    void Return()
    {
        if (nearEnemie == null)
        {
            if (transform.position == new Vector3(0f, 0f))
            {
                h = 0;
                v = 0;
            }
            else
            {
                GoTo(new Vector3(0f, 0f));
            }
        }  
    }

    void ClampPosition()
    {
        transform.position = new Vector3(
                                        Mathf.Clamp(transform.position.x, -4f, 8f),
                                        Mathf.Clamp(transform.position.y, -3f, 3f),
                                        0);
    }

    void MoveDetection()
    {
        float curX;
        curX = (float)System.Math.Round(transform.position.x, 1);
        
        if (curX != oldX)
        {
            h = (float)System.Math.Round(oldX - curX, 1); 
           
        }        
       
        oldX = curX;
             
        Animate(h);

    }
    void manualWalking()
    {
        GameObject touched = touchController.TouchedObject();
        if (touched != null)
        {
            if (touched.tag == "Monster")
            {
                touched.GetComponent<ColorController>().selected = true;
                if (touched.GetComponent<StatusController>().hPoints > 0)
                {
                    nearEnemie = touched;
                }
                
            }
        }
      
    }

    void GoTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    void GoTo(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    void Animate(float h)
    {
        anim.SetFloat("h", h);
       
    }
   
    

    void Attack(GameObject nearEnemie)
    {   
       if(nearEnemie != null && GetDistance(nearEnemie) <= attackRange)      
        if (attackTimer >= attackSpeed)
        {
            attackTimer = 0;
            anim.SetTrigger("Attack");
                StartCoroutine(AttackRoutine(0.4f, nearEnemie));
        }
        
    }

    IEnumerator AttackRoutine(float time, GameObject enemie)
    {
        yield return new WaitForSeconds(time);
        Harm(enemie);
    }

    void placeCannon()
    {
        if (h <= 0)
        {
            cannon.transform.localPosition = new Vector3(0.7f, 0.45f, 0);
        }
        else
        {
            cannon.transform.localPosition = new Vector3(-0.7f, 0.45f, 0);
        }    
             

    }
    

    public void Harm(GameObject nearEnemie)
    {
        if (nearEnemie != null)
        {
            damageController.TakeDamage(nearEnemie, status.pAttack, status.mAttack, status.pDefense, status.mDefense, status.hPoints, status.mPoints,
                status.criticalChance, status.criticalMultiplier, status.evasionChance, status.accuracy, status.blockChance);
        }
    }

    private void LateUpdate()
    {

        Attack(nearEnemie);

    }
    
}