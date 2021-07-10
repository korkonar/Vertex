using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Spawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy13D;
    public GameObject enemy23D;
    public GameObject enemy33D;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject Boss;
    public int level;
    private float cooldown;
    SoundManager sounds;
    // Start is called before the first frame update
    void Start()
    {
        cooldown=0.0f;
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown-=Time.deltaTime;
        switch(level){
            case 1:
                if(cooldown<=0.0f){
                Instantiate(enemy1,new Vector3(transform.position.x,transform.position.y-20,120.0f),Quaternion.identity);
                cooldown=4f*(GameObject.FindGameObjectsWithTag("Enemy").Length/2)+Random.Range(-1.0f,1.0f);
                }
                break;
            case 2:
                if(cooldown<=0.0f){
                    int i=Random.Range(0,3);
                    int p=Random.Range(-20,21);
                    switch(i){
                        case 0:
                            Instantiate(enemy1,new Vector3(p,transform.position.y-20,120.0f),Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(enemy2,new Vector3(p,transform.position.y-20,120.0f),Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(enemy3,new Vector3(p,transform.position.y-20,120.0f),Quaternion.identity);
                            break;
                    }
                    cooldown=Random.Range(2.0f,3.5f)*((GameObject.FindGameObjectsWithTag("Enemy").Length+1)/4);
                }
                break;
            case 3:
                if(cooldown<=0.0f){
                    int i=Random.Range(0,7);
                    int p=Random.Range(-20,21);
                    sounds.PlayEnemySpawn();
                    switch(i){
                        case 0:
                            Instantiate(enemy13D,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(enemy23D,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(enemy33D,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(enemy4,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(enemy5,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(enemy6,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(enemy7,new Vector3(p,transform.position.y,Random.Range(116.0f,123.0f)),Quaternion.identity);
                            break;
                    }
                    cooldown=Random.Range(2.0f,3.5f)*((GameObject.FindGameObjectsWithTag("Enemy").Length+1)/4);
                }
            break;
            case 4:
                sounds.PlayEnemySpawn();
                Instantiate(Boss,new Vector3(0,transform.position.y,120.0f),Quaternion.identity);
                this.enabled=false;
            break;
        }
        
        
    }
}
