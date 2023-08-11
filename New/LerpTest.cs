using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Vector3 Point;
    public float zDistance;
    public GameObject TurnHelper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TurnHelper.transform.position, 0.1f);
        transform.LookAt(TurnHelper.transform);
    }
}
