using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    Camera cam;
    float height = Screen.height;
    float width = Screen.width;
    float coef; 
    // Use this for initialization
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void Start()
    {

        coef = width / height;

        if (coef > 1.35f)
        {
            cam.orthographicSize = 5f;
        }
        else
            cam.orthographicSize = 6.62f;     
        

    }


}
