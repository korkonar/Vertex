using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public int poolSize;
    int poolIndex;
    public GameObject poolObject;
    GameObject[] pool;
    // Start is called before the first frame update
    void Start()
    {
        pool=new GameObject[poolSize];
        for(int i=0;i<poolSize;i++){
           pool[i]=Instantiate(poolObject,Vector3.zero,Quaternion.identity);
        }
    }

    public void usePool(Vector3 pos){
        pool[poolIndex].transform.position=pos;
        pool[poolIndex++].GetComponent<ParticleSystem>().Play();
        //Debug.Break();
        if(poolIndex>=poolSize)poolIndex=0;
    }


}
