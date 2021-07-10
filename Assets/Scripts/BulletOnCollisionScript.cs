using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnCollisionScript : MonoBehaviour
{
    public bool player;
    public int dmg=1;
    public ParticlePool pool;
    SoundManager sounds;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.position.y<65.0f && (col.tag.Equals("Player") || col.tag.Equals("Enemy"))){
            col.gameObject.GetComponent<healthBehaviour>().getHit(dmg);
            if(col.tag.Equals("Enemy")){
                pool.usePool(this.transform.position+Vector3.down);
            }else{
                pool.usePool(this.transform.position+Vector3.up);
            }
        }else{
            if(player && col.tag.Equals("Bullet")){
                pool.usePool(this.transform.position);
                sounds.PlayBulletsCollide();
            }
        }
        Destroy(this.gameObject);
    }

    void Start(){
        pool=GameObject.FindGameObjectWithTag("Spawner").GetComponent<ParticlePool>();
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    void Update(){
        
        if(transform.position.y>200 || transform.position.y<-150){
            Destroy(this.gameObject);
        }
    }
}
