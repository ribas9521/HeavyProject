using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
   
    
    // Use this for initialization
    private void Awake()
    {
      

    }
   
    void Start()
    {

        camconfig();

    }
    private void Update()
    {
        camconfig();
    }

    void camconfig()
    {
        Camera cam = GetComponent<Camera>();
        float height = Screen.height;
        float width = Screen.width;
        float coef;
        
        coef = Mathf.Round((width / height)*100)/100;
      
        if(coef == 1.33f) //1024x768
            cam.orthographicSize = 7f;
        if(coef ==1.71f)//1024x600
            cam.orthographicSize = 5.5f;
        if (coef == 1.6f)//1280 x 800
            cam.orthographicSize = 5.8f;
        if (coef == 1.78f)//Common smartphones
            cam.orthographicSize = 5.3f;



    }


}
