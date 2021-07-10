using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public float cooldown;
    private float cooldownTime;
    public Transform[] shootingPoints;
    public GameObject bullet;
    public float speed;
    SoundManager sounds;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTime=cooldown;
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<EnemyMovement>().dimension==1){
            if(transform.position.y<75.5f){
                cooldownTime-=Time.deltaTime;
                if(cooldownTime<=0.0f){
                    foreach(Transform t in shootingPoints){
                        sounds.PlayEnemyShoot();
                        GameObject b = Instantiate(bullet,t.transform.position,Quaternion.Euler(0,0,-180));
                        if(GetComponent<Rigidbody2D>()==null){
                            b.GetComponent<Rigidbody>().AddForce(Vector3.down*speed);
                        }else{
                            b.GetComponent<Rigidbody2D>().AddForce(Vector2.down*speed);
                        }
                       if(b.GetComponent<BulletOnCollisionScript>()==null){
                            b.GetComponent<BulletOnCollisionScript3D>().dmg=1;
                        }else{
                            b.GetComponent<BulletOnCollisionScript>().dmg=1;
                        }
                    }
                    cooldownTime=cooldown;
                }
            }
        }else{
            cooldownTime-=Time.deltaTime;
            if(cooldownTime<=0.0f){
                foreach(Transform t in shootingPoints){
                    sounds.PlayEnemyShoot();
                    GameObject b = Instantiate(bullet,t.transform.position,Quaternion.Euler(0,0,-90));
                    if(GetComponent<Rigidbody2D>()==null){
                        b.GetComponent<Rigidbody>().AddForce(Vector3.down*speed);
                    }else{
                        b.GetComponent<Rigidbody2D>().AddForce(Vector2.down*speed);
                    }
                   if(b.GetComponent<BulletOnCollisionScript>()==null){
                        b.GetComponent<BulletOnCollisionScript3D>().dmg=1;
                    }else{
                        b.GetComponent<BulletOnCollisionScript>().dmg=1;
                    }
                }
                cooldownTime=cooldown;
            }
        }
    }
}
