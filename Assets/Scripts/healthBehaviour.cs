using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class healthBehaviour : MonoBehaviour
{
    public Slider slider;
    public GameObject powerUp;
    private bool hit;
    private float time;
    public static int numKills=0;
    public static int reachKills=4;
    public int health;
    bool dead;
    public GameObject deathParticles;
    SoundManager sounds;
    float invunerable=0.5f;
    bool safe=false;
    int TimesHit=0;
    // Start is called before the first frame update
    void Start()
    {
        hit =false;
        time=1.0f;
        slider.maxValue=health;
        slider.value=slider.maxValue;
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(safe){
            invunerable-=Time.deltaTime;
            if(invunerable<=0){
                safe=false;
                invunerable=0.5f;
            }
        }
        if(hit){
            if(time==1.0f)slider.gameObject.SetActive(true);
            time-=Time.deltaTime;
            if(time<=0){
                hit=false;
                time=1.0f;
                slider.gameObject.SetActive(false);
            }
        }
    }

    public void getHit(int dmg){
        if(!dead){
            if((this.tag.Equals("Player") && !safe) || this.tag.Equals("Enemy")){
                safe=true;
                health-=dmg;
                slider.value=health;
            }
            if(this.name!="4DBoss")hit=true;
            if(health<=0){
                dead=true;
                Instantiate(deathParticles,transform.position,Quaternion.identity);
                if(this.tag.Equals("Enemy")){
                    
                    numKills++;
                    //print(numKills);
                    if(this.name=="4DBoss"){
                        sounds.PlayBossDie();
                        KongregateAPIBehaviour.gameFinished=true;
                        KongregateAPIBehaviour.SendFinishedGame();
                        KongregateAPIBehaviour.setScore((numKills*5)-TimesHit);
                        levelMenu.Win();
                        this.GetComponent<BossShoot>().enabled=false;
                        this.GetComponent<Animator>().enabled=false;
                    }else{
                        sounds.PlayEnemyDie();
                        this.GetComponent<enemyShoot>().enabled=false;
                    }
                    if(numKills>=reachKills){
                        if(Random.Range(0.0f,0.5f)+((numKills)/reachKills)>=1.1f)
                        sounds.PlayItemsSound();
                        Instantiate(powerUp,this.transform.position,Quaternion.identity);
                    }
                }else{
                    sounds.PlayPlayerDie();
                    KongregateAPIBehaviour.setScore((numKills*5)-TimesHit);
                    levelMenu.meDead();
                }
                Destroy(this.gameObject,0.2f);
            }
            if(this.tag.Equals("Enemy")){
                sounds.PlayEnemyHit();
            }else{
                sounds.PlayPlayerHit();
                TimesHit++;
            }
        }
    }
    
}
