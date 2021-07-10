using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTowards : MonoBehaviour
{
    GameObject player;  
    float speed=-0.5f;
    SoundManager sounds;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
        transform.DOShakeScale(10.0f,0.5f,1,90,false);
        if(this.name.Equals("Item2D(Clone)")){
            transform.DOShakeRotation(10.0f,new Vector3(0.0f,0.0f,180.0f),1,90,false);
        }else{
            transform.DOShakeRotation(10.0f,180.0f,1,90,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!levelMenu.Paused){
            transform.position = transform.position+Vector3.up*speed;
            if(transform.position.x +3f >= player.transform.position.x && transform.position.x -3f <= player.transform.position.x && transform.position.y +2.5f >= player.transform.position.y && transform.position.y -2.5f <= player.transform.position.y){
                sounds.PlayItemsPickUp();
                player.GetComponent<playerVertexAdd>().change=true;
                Destroy(this.gameObject);
            }
        }
    }
}
