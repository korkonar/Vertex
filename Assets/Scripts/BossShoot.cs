using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject BossBullet;
    int dir=0;
    public float speed;

    public float cooldown;
    public float cooldownTime;
    SoundManager sounds;
    GameObject player;
    int a=0;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTime=cooldown;
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTime-=Time.deltaTime;
        if(cooldownTime<=0.0f){
            sounds.PlayEnemyShoot();
            GameObject b = Instantiate(BossBullet,this.transform.position,Quaternion.Euler(90,90,0));
            Vector3 dir=player.transform.position-this.transform.position;
            dir.Normalize();
            switch(a){
                case 0:
                    b.GetComponent<Rigidbody>().AddForce(dir*speed);
                    break;
                case 1:
                    b.GetComponent<Rigidbody>().AddForce(dir*speed);
                    b.transform.Rotate(new Vector3(0,90,0),Space.World);
                    break;
            }
            a++;
            if(a>1)a=0;
            cooldownTime=cooldown;
        }
    }
}
