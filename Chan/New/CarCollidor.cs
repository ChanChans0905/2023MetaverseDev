using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRPlugin;

public class CarCollidor : MonoBehaviour
{
    Vector3 StartPos;
    Quaternion StartRot;

    void Start()
    {
        StartPos = transform.position;
        StartRot = transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car" || other.tag == "EndPoint")
        {
            transform.position = StartPos;
            transform.rotation = StartRot;
        }

    }
}
