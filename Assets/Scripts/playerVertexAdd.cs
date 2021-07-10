using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class playerVertexAdd : MonoBehaviour
{

    float nextvertexFill;
    int numVertex;
    CinemachineVirtualCamera cam2D;
    CinemachineVirtualCamera cam3D;
    public GameObject twoVertex;
    public GameObject enemySpawner;
    public ParticleSystem particles;
    public RectTransform Left;
    public RectTransform Right;
    public bool type;
    public bool change;

    GameObject sun;
    GameObject light;
    GameObject plane;
    AudioSource music;
    SoundManager sounds;

    // Start is called before the first frame update
    void Start()
    {
        nextvertexFill=0;
        enemySpawner= GameObject.FindGameObjectWithTag("Spawner");
        particles=GameObject.Find("Particle System2D").GetComponentInChildren<ParticleSystem>();
        cam2D=GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cam3D=GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        sun=GameObject.Find("Sun");
        plane=GameObject.Find("Plane(Clone)");
        light=GameObject.Find("SunDirectional Light");
        music=GameObject.Find("Music").GetComponent<AudioSource>();
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(change){
            if(type){

                this.GetComponent<Movement>().enabled=false;
                this.GetComponent<Shoot>().enabled=false;

                enemySpawner.GetComponent<Level1Spawn>().enabled=false;
                sounds.PlayPlayerGrow();
                //particles.Pause();
                Time.timeScale=0.3f;

                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy")){
                    Destroy(go);
                }
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Bullet")){
                    Destroy(go);
                }
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("item")){
                    Destroy(go);
                }

                Left.DOScaleX(0.2f,1.2f);
                Right.DOScaleX(0.2f,1.2f);
                
                Sequence soundSeq = DOTween.Sequence();
                soundSeq.Append(music.DOPitch(0.6f,0.6f));
                soundSeq.Append(music.DOPitch(1.0f,0.6f));

                Sequence seq1 = DOTween.Sequence().SetAutoKill(false);

                seq1.Append(transform.DOMove(new Vector3(0.0f,-20.0f,117.0f),0.2f,true));

                GameObject obj=Instantiate(twoVertex,new Vector3(0.0f,-20.0f,117.0f),Quaternion.identity);
                obj.transform.localScale=Vector3.zero;

                seq1.Append(transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(obj.transform.DOScale(0.33f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(obj.transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(transform.DOScale(0.66f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(obj.transform.DOScale(0.66f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(obj.transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(transform.DOScale(0.33f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(obj.transform.DOScale(1.0f,0.1f).SetEase(Ease.OutExpo));

                Destroy(this.gameObject,1.2f);
            }else{
                this.GetComponent<Movement>().enabled=false;
                this.GetComponent<Shoot>().enabled=false;

                enemySpawner.GetComponent<Level1Spawn>().enabled=false;

                sounds.PlayPlayerGrow();
                //particles.Pause();
                Time.timeScale=0.2f;

                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy")){
                    Destroy(go);
                }
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Bullet")){
                    Destroy(go);
                }
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("item")){
                    Destroy(go);
                }
        	    
                Sequence soundSeq = DOTween.Sequence();
                soundSeq.Append(music.DOPitch(0.6f,0.6f));
                soundSeq.Append(music.DOPitch(1.0f,0.6f));

                cam3D.enabled=true;
                GameObject.Find("1D-2DCanvas").SetActive(false);

                cam2D.enabled=false;

                plane.GetComponent<MeshRenderer>().enabled=true;
                light.GetComponent<Light>().enabled=true;
                sun.GetComponent<SpriteRenderer>().enabled=true;

                
                Sequence seq1 = DOTween.Sequence().SetAutoKill(false);

                seq1.Append(transform.DOMove(new Vector3(0.0f,-20.0f,120.0f),0.2f,true));

                GameObject obj=Instantiate(twoVertex,new Vector3(0.0f,-20.0f,119.0f),Quaternion.identity);
                obj.transform.localScale=Vector3.zero;

                seq1.Append(transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(obj.transform.DOScale(0.33f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(obj.transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(transform.DOScale(0.66f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(obj.transform.DOScale(0.66f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(obj.transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(transform.DOScale(0.33f,0.1f).SetEase(Ease.OutExpo));

                seq1.Append(transform.DOScale(0.0f,0.1f).SetEase(Ease.OutExpo));
                seq1.Append(obj.transform.DOScale(1.0f,0.1f).SetEase(Ease.OutExpo));


                Destroy(this.gameObject,1.2f);
            }
            change=false;
        }
    }

}
