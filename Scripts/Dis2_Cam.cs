using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis2_Cam : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject scooter;

    private void Start()
    {
        cam.transform.position = scooter.transform.position + new Vector3(0f, 6f, -6f);
        cam.transform.LookAt(scooter.transform.position);

    }
    // Update is called once per frame
    void Update()
    {
        cam.transform.position = scooter.transform.position + new Vector3(0f, 6f, -6f);
        cam.transform.LookAt(scooter.transform.position);

    }
}
