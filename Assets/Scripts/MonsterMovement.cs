using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MonsterMovement : MonoBehaviour {
    Transform point1, point2, point3, point4, point5, point6;
    int way;
    int reachedPoint =0;
    public float moveSpeed;
    public float initialMoveSpeed;
    StatusController status;
    public GameObject slider;
    GameObject healthBar;
   
    public bool isTouched;
    bool wasKilled;
    public bool isStunned = false;
    float halfMoveSpeed;
    ColorController colorController;
    GameController gameController;
    public float offsetX, offSetY;
   
    

    void Awake () {
        initialMoveSpeed = moveSpeed;
        status = GetComponent<StatusController>();
        healthBar = Instantiate(slider) as GameObject;
        colorController = GetComponent<ColorController>();
        
        isTouched = false;
        wasKilled = true;
        halfMoveSpeed = moveSpeed / 2;
        gameController = GameObject.Find("GameMananger").GetComponent<GameController>();
        healthBar.GetComponent<Slider>().maxValue = status.maxHPoints;

        if (transform.position.y > 0)

            way = 0;

        else if (transform.position.y < 0)
            way = 1;
        else
            Debug.Log("Caminho não encontrado! Spawner no lugar errado");

        
	}

    void Start()
    {
        GameObject points = GameObject.Find("Points");
        if(way == 0)
        {
            point1 = points.transform.Find("Point1").transform;
            point2 = points.transform.Find("Point2").transform;
            point3 = points.transform.Find("Point3").transform;

        }
        else if (way == 1)
        {
            point4 = points.transform.Find("Point4").transform;
            point5 = points.transform.Find("Point5").transform;
            point6 = points.transform.Find("Point6").transform;

        }
    }

    // Update is called once per frame
    void Update () {
        
       if(way == 0)
        {
            if (reachedPoint == 0)
                GoTo(point1);
            else if (reachedPoint == 1)
                GoTo(point2);
            else if (reachedPoint == 2)
                GoTo(point3);
                
        }
       else if(way == 1)
        {
            if (reachedPoint == 0)
                GoTo(point4);
            else if (reachedPoint == 4) {
                GoTo(point5);}
            else if (reachedPoint == 5)
                GoTo(point6);

        }
        
        Die();
        SliderControl();
        
    }

    void SliderControl()
    {
        healthBar.transform.SetParent(GameObject.Find("Canvas").transform);
        healthBar.GetComponent<Slider>().value= status.hPoints;
        healthBar.transform.position = new Vector3(transform.position.x+ offsetX, transform.position.y+offSetY);
    }

    void GoTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {   if (way == 0)
        {
            if (other.name == "Point1")
                reachedPoint = 1;
            if (other.name == "Point2")
                reachedPoint = 2;
        }
        if (way == 1)
        {
            if (other.name == "Point4")
                reachedPoint = 4;
            if (other.name == "Point5")
                reachedPoint = 5;
        }
        if (other.name == "Crystal")
        {
            wasKilled = false;
            Destroy(gameObject);
        }              
    }

    public void Stun(float stunTime)
    {
        isStunned = true;
        StartCoroutine(StunRoutine(stunTime));
    }
    IEnumerator StunRoutine(float stunTime)
    {
        float formerMoveSpeed = moveSpeed;
        moveSpeed = 0;
        yield return new WaitForSecondsRealtime(stunTime);
        moveSpeed = formerMoveSpeed;
        isStunned = false;
    }

    void Die()
    {
        if(status.hPoints <= status.maxHPoints * 0.3f)
        {
            colorController.injured = true;
            if(moveSpeed > 0)
            {
                moveSpeed = halfMoveSpeed;
            }
            gameObject.layer = 9;
           
            foreach(SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.sortingLayerName = "Injured";
            }
        }
        if (status.hPoints <= 0 )
        {        
          
            Destroy(gameObject);           
        }       
        
    }

    public void touchKill()
    {
        if(status.hPoints <= status.maxHPoints * 0.3f)
        {            
            status.reward += status.reward * 0.5f;
            Destroy(gameObject);
        }
    }

   
    
    void OnDestroy()
    {
        gameController.monsterDeath(gameObject);
        if(wasKilled)
        gameController.UpdateScore((int)status.reward);     
        Destroy(healthBar);
    }
}
