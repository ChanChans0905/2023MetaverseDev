using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = .1f;
    public bool wayPointTrigger;

    void Start()
    {

    }

    void Update()
    {
        float xD = Input.GetAxis("Horizontal");
        float zD = Input.GetAxis("Vertical");

        Vector3 moveD = new Vector3(-xD, 0.0f, -zD);

        transform.position += moveD * speed * 0.5f;
    }
}
