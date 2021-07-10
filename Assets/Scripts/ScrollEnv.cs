using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ScrollEnv : MonoBehaviour
{
    public GameObject CurrScanLines;
    public GameObject ScanLinePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(CurrScanLines.transform.localPosition.y<=20){
           //CurrScanLines=Instantiate(ScanLinePrefab,new Vector3(0,-268.8f,0),Quaternion.identity,transform.parent);
           CurrScanLines=Instantiate(ScanLinePrefab);
           CurrScanLines.transform.localPosition=new Vector3(0,193,180);
           CurrScanLines.transform.DOMoveZ(130.0f,1.0f,false);
       }
    }
}
