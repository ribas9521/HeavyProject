using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleTextController : MonoBehaviour {
    public GameObject bText;
    GameObject myBText;
    GameObject canvas;
 
    

	// Use this for initialization
	void Awake () {
        canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    void spawnText()
    {
       
        myBText = Instantiate(bText) as GameObject;
        myBText.transform.SetParent(canvas.transform);
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 newPos = new Vector3(wantedPos.x + 80, wantedPos.y + 35f, wantedPos.z);
        myBText.transform.position = newPos;
      

    }
   
    public void damage(float amount)
    {
        spawnText();
        myBText.GetComponent<Text>().text = amount.ToString();
        myBText.GetComponent<Text>().color = Color.yellow;
        Destroy(myBText, .5f);
    }
    public void miss()
    {
        spawnText();
        myBText.GetComponent<Text>().text = "MISS";
        myBText.GetComponent<Text>().color = Color.white;
        Destroy(myBText, .5f);
    }
    public void modificator(string type)
    {

    }
    public void critical(float amount)
    {
        spawnText();
        myBText.GetComponent<Text>().text = amount.ToString();
        myBText.GetComponent<Text>().color = Color.red;
        myBText.GetComponent<Text>().fontSize += 25;
        Destroy(myBText, .5f);

    }
    public void block()
    {
        spawnText();
        myBText.GetComponent<Text>().text = "BLOCK";
        myBText.GetComponent<Text>().color = Color.gray;
        Destroy(myBText, .5f);

    }
}
