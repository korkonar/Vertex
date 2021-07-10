using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossScript : MonoBehaviour
{
    healthBehaviour health;
    Sequence seq;
    int sequence;

    // Start is called before the first frame update
    void Start()
    {
        seq= DOTween.Sequence();
        health=GetComponent<healthBehaviour>();
        sequence=0;
        startSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health<= 10 && sequence==1){
            sequence=2;
            endSequence();
        }
        if(health.health<=20 && sequence==0){
            sequence=1;
            midSequence();
        }
    }

    void startSequence(){

        seq.Append(transform.DOMove(new Vector3(0,20,0),5,false));
        seq.Append(transform.DOShakePosition(150,new Vector3(100,0,0),1,0,false,false));
    }

    void midSequence(){
        seq.Kill();
    }

    void endSequence(){

    }
}
