using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public GameObject item;
    public string type;

    public void adjustSprite()
    {
        if(item == null)
            return;
        
        if (item.GetComponent<ItemController>().type == "Helmet")
        {
            transform.Find("Img").GetComponent<RectTransform>().localPosition = new Vector3(0.1f, 25f, 0f);
        }
        if (item.GetComponent<ItemController>().type == "1H" ||
            item.GetComponent<ItemController>().type == "2H")
        {
            transform.Find("Img").transform.localPosition = new Vector3(0.1f, 28.3f, 0f);
        }
        
    }
    
}
