using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int dimension;
    public float speed;

    private Vector2 velocity;
    private Vector3 velocity3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch(dimension){
            case 1:
                if(Input.GetAxisRaw("Vertical")>0.0f){  
                    velocity=Vector2.up;
                }else if(Input.GetAxisRaw("Vertical")<0.0f){
                    velocity=Vector2.down;
                }
                velocity.Normalize();
                if(transform.position.y>-20.0f){
                    velocity+=Vector2.down*Mathf.InverseLerp(-20,-13,transform.position.y);
                }else if(transform.position.y<-35.0f){
                    velocity+=Vector2.up*Mathf.InverseLerp(-35,-42,transform.position.y);
                }   
                transform.position+=(Vector3)velocity*speed*Time.deltaTime;
                transform.position=new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-42.0f,-13.0f), 120.0f);
                velocity=Vector2.zero;
                break;
            case 2:
                if(Input.GetAxisRaw("Vertical")>0.0f){  
                    velocity+=Vector2.up;
                }else if(Input.GetAxisRaw("Vertical")<0.0f){
                    velocity+=Vector2.down;
                }
                if(Input.GetAxisRaw("Horizontal")>0.0f){  
                    velocity+=Vector2.right;
                }else if(Input.GetAxisRaw("Horizontal")<0.0f){
                    velocity+=Vector2.left;
                }
                velocity.Normalize();
                if(transform.position.y>-20.0f){
                    
                    velocity+=Vector2.down*Mathf.InverseLerp(-20,-13,transform.position.y);
                }else if(transform.position.y<-35.0f){
                    
                    velocity+=Vector2.up*Mathf.InverseLerp(-35,-42,transform.position.y);
                }
                if(transform.position.x>35.0f){
                    velocity+=Vector2.left*Mathf.InverseLerp(35,50,transform.position.x);
                }else if(transform.position.x<-35.0f){
                    velocity+=Vector2.right*Mathf.InverseLerp(-35,-50,transform.position.x);
                }   
                //print(velocity); 
                transform.position+=(Vector3)velocity*speed*Time.deltaTime;
                transform.position=new Vector3(Mathf.Clamp(transform.position.x,-50.0f,50.0f),Mathf.Clamp(transform.position.y,-42.0f,-13.0f),120.0f);
                velocity=Vector2.zero;
                break;
            case 3:
                if(Input.GetAxisRaw("Vertical")>0.0f){  
                    velocity3+=Vector3.back;
                }else if(Input.GetAxisRaw("Vertical")<0.0f){
                    velocity3+=Vector3.forward;
                }
                if(Input.GetAxisRaw("Horizontal")>0.0f){  
                    velocity3+=Vector3.right;
                }else if(Input.GetAxisRaw("Horizontal")<0.0f){
                    velocity3+=Vector3.left;
                }
                velocity3.Normalize();
                if(transform.position.z>120.5f){
                    
                    velocity3+=Vector3.back*Mathf.InverseLerp(120.5f,123,transform.position.z);
                }else if(transform.position.z<119.0f){
                    
                    velocity3+=Vector3.forward*Mathf.InverseLerp(119,115.5f,transform.position.z);
                }
                if(transform.position.x>18.0f){
                    velocity3+=Vector3.left*Mathf.InverseLerp(18,23,transform.position.x);
                }else if(transform.position.x<-18.0f){
                    velocity3+=Vector3.right*Mathf.InverseLerp(-18,-23,transform.position.x);
                }   
                //print(velocity); 
                transform.position+=velocity3*speed*Time.deltaTime;
                transform.position=new Vector3(Mathf.Clamp(transform.position.x,-23.0f,23.0f),-20.0f, Mathf.Clamp(transform.position.z,115.5f,123.0f));
                velocity3=Vector3.zero;
                break;
        }
    }
}
