using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int dimension;
    public float speed;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(dimension){
            case 1:
                velocity=Vector3.down;
                transform.position+=velocity*speed*Time.deltaTime;
                velocity=Vector2.zero;
                break;
            case 2:
                velocity=Vector3.down;
                transform.position+=velocity*speed*Time.deltaTime;
                velocity=Vector2.zero;
                break;
            case 3:
                break;
        }
        if(transform.position.y<=-60)Destroy(this.gameObject);
    }
}
