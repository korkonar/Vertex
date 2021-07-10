using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Space]

    [Header("Offset")]
    public Vector3 offset = Vector3.zero;

    [Space]

    [Header("Limits")]
    public Vector2 limits = new Vector2(5, 3);

    [Space]

    [Header("Smooth Damp Time")]
    [Range(0, 1)]
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        //if (!Application.isPlaying)
        //{
        //    transform.localPosition = offset;
        //}

        FollowTarget(target);
        
    }

    void LateUpdate()
    {
        Vector3 localPos = transform.localPosition;

        transform.localPosition = new Vector3(Mathf.Clamp(localPos.x,localPos.x -limits.x, localPos.x+limits.x),localPos.y , Mathf.Clamp(localPos.z, localPos.z-limits.y,localPos.z+ limits.y));
    }

    public void FollowTarget(Transform t)
    {
        Vector3 localPos = transform.localPosition;
        Vector3 targetLocalPos;
        if(t!=null){
            targetLocalPos = t.transform.localPosition;
        }else{
            targetLocalPos =new Vector3(0.0f,-20.0f,120.0f);
        }
        
        transform.localPosition = Vector3.SmoothDamp(localPos, new Vector3(targetLocalPos.x + offset.x, localPos.y, targetLocalPos.z + offset.y), ref velocity, smoothTime);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawLine(new Vector3(-limits.x, transform.position.y, -limits.y), new Vector3(limits.x, -limits.y, transform.position.z));
    //    Gizmos.DrawLine(new Vector3(-limits.x, transform.position.y, limits.y), new Vector3(limits.x, limits.y, transform.position.z));
    //    Gizmos.DrawLine(new Vector3(-limits.x, transform.position.y, limits.y), new Vector3(-limits.x, limits.y, transform.position.z));
    //    Gizmos.DrawLine(new Vector3(limits.x, transform.position.y, -limits.y), new Vector3(limits.x, limits.y, transform.position.z));
    //}
}