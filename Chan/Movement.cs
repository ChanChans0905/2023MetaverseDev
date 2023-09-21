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
        float xD = Input.GetAxis("Vertical");
        float zD = Input.GetAxis("Horizontal");

        Vector3 moveD = new Vector3(-xD, 0.0f, -zD);

        //transform.position += moveD * speed * 0.5f;
        transform.Translate(50f * Input.GetAxis("Vertical") * Time.deltaTime, 0f,0f);
        transform.Rotate(Vector3.up  * 50f * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
