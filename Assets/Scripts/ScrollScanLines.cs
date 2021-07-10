using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScanLines : MonoBehaviour
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
       if(CurrScanLines.transform.localPosition.y>=140){
           //CurrScanLines=Instantiate(ScanLinePrefab,new Vector3(0,-268.8f,0),Quaternion.identity,transform.parent);
           CurrScanLines=Instantiate(ScanLinePrefab,transform.parent);
           CurrScanLines.transform.localPosition=new Vector3(0,-1300,0);
       }
    }
}
