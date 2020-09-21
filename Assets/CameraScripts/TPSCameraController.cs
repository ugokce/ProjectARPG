using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    public Transform target;
    public float heightThresold;
    public float distance;
    [Range(0, 1f)]
    public float followLerpX;
    [Range(0, 1f)]
    public float followLerpY;
    [Range(0, 1f)]
    public float followLerpZ;
    [Range(0, 1f)]
    public float lookAtLerp;

    void FixedUpdate()
    {  
        Vector3 targetPoint = target.TransformPoint(0, heightThresold, -distance);
        float newPosX = Mathf.Lerp(transform.position.x, targetPoint.x, followLerpX);
        float newPosY = Mathf.LerpUnclamped(transform.position.y, targetPoint.y, followLerpY);
        float newPosZ = Mathf.Lerp(transform.position.z, targetPoint.z, followLerpZ);
        Vector3 newPos = new Vector3(newPosX, newPosY, newPosZ);

        Vector3 lookDir = target.position - transform.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDir.normalized), lookAtLerp);
        transform.position = newPos;
       
        changeDistance();
    }

    void changeDistance()
    {
        distance += Input.mouseScrollDelta.y;
        heightThresold += Input.mouseScrollDelta.y;
    }
}
