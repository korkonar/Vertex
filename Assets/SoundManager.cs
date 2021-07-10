using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    public int numSources;
    AudioSource[] sources;
    int sourceIndex;
    public AudioClip playerShoot;
    public AudioClip enemyShoot;
    public AudioClip playerHit;
    public AudioClip enemyHit;
    public AudioClip enemySpawn;
    public AudioClip playerGrow;
    public AudioClip playerDie;
    public AudioClip enemyDie;
    public AudioClip bossDie;
    public AudioClip bulletCollide;
    public AudioClip itemSound;
    public AudioClip itemPickUp;
    public AudioClip pause;
    public AudioClip unpause;
    // Start is called before the first frame update
    void Start()
    {
        sources=new AudioSource[numSources];
        for(int i=0;i<numSources;i++){
            sources[i]=this.gameObject.AddComponent<AudioSource>();
            sources[i].loop=false;
            sources[i].volume=0.6f;
        }
        sourceIndex=0;
    }

    public void PlayPlayerShoot(){
        sources[sourceIndex].clip=playerShoot;
        sources[sourceIndex].pitch=Random.Range(0.85f,1.1f);
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayEnemyShoot(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=enemyShoot;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayPlayerHit(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=playerHit;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayEnemyHit(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=enemyHit;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayEnemySpawn(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=enemySpawn;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayPlayerGrow(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=playerGrow;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayPlayerDie(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=playerDie;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayEnemyDie(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=enemyDie;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayBossDie(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=bossDie;
        sources[sourceIndex++].Play();
        testIndexReset();
    }   
    public void PlayBulletsCollide(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=bulletCollide;
        sources[sourceIndex++].Play();
        testIndexReset();
    } 
    public void PlayItemsSound(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=itemSound;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayItemsPickUp(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=itemPickUp;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayPause(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=pause;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    public void PlayUnPause(){
        sources[sourceIndex].pitch=1.0f;
        sources[sourceIndex].clip=unpause;
        sources[sourceIndex++].Play();
        testIndexReset();
    }
    void testIndexReset(){
        if(sourceIndex>=numSources)sourceIndex=0;
    }
}
