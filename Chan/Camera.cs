using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Update()
    {
        Vector3 desiredP = target.position + offset;
        Vector3 SmoothedP = Vector3.Lerp(transform.position, desiredP, smoothSpeed);
        transform.position = SmoothedP;

        transform.LookAt(target);
    }
}
