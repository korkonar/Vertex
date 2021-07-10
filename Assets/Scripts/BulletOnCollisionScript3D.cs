using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnCollisionScript3D : MonoBehaviour
{
    public bool player;
    public int dmg=1;
    public ParticlePool pool;
    SoundManager sounds;

    void OnTriggerEnter(Collider col)
    {
        if((col.tag.Equals("Player") || col.tag.Equals("Enemy"))){
            col.gameObject.GetComponent<healthBehaviour>().getHit(dmg);
            pool.usePool(this.transform.position);
        }else{
            if(player){
                sounds.PlayBulletsCollide();
                pool.usePool(this.transform.position);}
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
