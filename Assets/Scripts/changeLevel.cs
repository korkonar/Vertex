using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLevel : MonoBehaviour
{
    bool change=false;
    public string name;
    public int vertices;
    public int level;
    int plus=4;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find(name)==null && !change){
            this.GetComponent<Movement>().enabled=true;
            this.GetComponent<Shoot>().enabled=true;

            Time.timeScale=1.0f;

            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Level1Spawn>().level=level;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Level1Spawn>().enabled=true;
            healthBehaviour.reachKills=(int)(healthBehaviour.numKills+0.7f*healthBehaviour.numKills);
            if(level==2){
                healthBehaviour.reachKills+=2*(plus++);
            }
            
            GameObject.FindGameObjectWithTag("Particles").GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerVertexAdd>().enabled=true;

            if(level==3 || level==4){
                healthBehaviour.reachKills-=4*(plus);
                GameObject.Find("CM vcam2").GetComponent<CameraFollow>().enabled=true;
                GameObject.Find("CM vcam2").GetComponent<CameraFollow>().target=this.transform;       
                GameObject.Find("Plane(Clone)").GetComponent<MoveEnv>().enabled=true;
            }
            //print(healthBehaviour.reachKills);
            change=true;
        }
    }
}
