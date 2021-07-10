using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    Camera cam;
    Vector3 originalPos;
    [Range(0.0f, 0.02f)]
    public float strength;
    // Start is called before the first frame update
    void Awake()
    {
        originalPos=this.transform.position;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position= originalPos-cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,50))*0.01f;
    }
}
