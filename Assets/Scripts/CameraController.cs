using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    Camera cam;
    float height = Screen.height;
    float width = Screen.width;
    float coef;
    GameObject player;
    
    // Use this for initialization
    private void Awake()
    {
        cam = GetComponent<Camera>();
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();

    }
    private void Start()
    {
              

    }
    private void Update()
    {
        
    }

    void camconfig()
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
