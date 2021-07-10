using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;
    public int dmg;
    public ParticleSystem particleSystem;
    public float speed;
    public float cooldown;
    private float cooldownTime;
    SoundManager sounds;
    // Start is called before the first frame update
    void Start()
    {
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
        cooldownTime=cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTime-=Time.deltaTime;
        if(cooldownTime<0 && Input.GetAxisRaw("Fire1")>0){
            sounds.PlayPlayerShoot();
            particleSystem.Play();
            cooldownTime=cooldown;
            GameObject b=null;
            if(GetComponent<Movement>().dimension==3){
                b=Instantiate(bullet,shootingPoint.position,Quaternion.Euler(0,0,90),null);
            }else{
                b=Instantiate(bullet,shootingPoint.position,Quaternion.Euler(0,0,0),null);
            }
            if(b.GetComponent<Rigidbody>()!=null){
                b.GetComponent<Rigidbody>().AddForce(Vector3.up*speed);
            }else{
                b.GetComponent<Rigidbody2D>().AddForce(Vector2.up*speed);
            }
            if(b.GetComponent<BulletOnCollisionScript>()==null){
                b.GetComponent<BulletOnCollisionScript3D>().dmg=this.dmg;
            }else{
                b.GetComponent<BulletOnCollisionScript>().dmg=this.dmg;
            }
            
        }
    }
}
