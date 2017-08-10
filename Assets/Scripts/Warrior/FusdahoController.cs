using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FusdahoController : MonoBehaviour {

    float x, y;
    public float speed;
    Transform col;
    ModificatorController mc;
    public GameObject stunPrefab;
    DamageController dc;
    public float damage;
    public float duration;
    // Use this for initialization
    private void Awake()
    {
        col = transform.Find("PhantomCollider");
        mc = GetComponent<ModificatorController>();
        dc = GetComponent<DamageController>();
    }
    void Start () {
        x = y = 0.1f;
        col.localScale = new Vector3(x, y, 1);
        Destroy(col.gameObject, 1.1f);
        Destroy(gameObject, duration + 1.5f);
        
	}
   

    // Update is called once per frame
    void Update () {
        grow();
	}
    public void grow()
    {
        if (col != null)
        {
            x += speed * Time.deltaTime;
            y += speed * Time.deltaTime;

            col.localScale = new Vector3(x, y, 1);
        }
        
    }
    public void collision(GameObject other)
    {
        if (other.CompareTag("Monster"))
        {
            mc.stun(other, stunPrefab, duration, 100);
            dc.TakeDamage(other, 0, damage, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
   

}
