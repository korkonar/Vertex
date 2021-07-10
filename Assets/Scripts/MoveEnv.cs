using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnv : MonoBehaviour
{
    float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed=-10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition=new Vector3(transform.localPosition.x,transform.localPosition.y+scrollSpeed*Time.deltaTime,transform.localPosition.z);
        if(transform.localPosition.y<-300){
            Destroy(this.gameObject);
        }
    }
}