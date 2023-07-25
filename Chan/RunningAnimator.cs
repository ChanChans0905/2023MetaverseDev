using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAnimator : MonoBehaviour
{
    float x;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime;
        transform.position = new Vector3(0,0,x);
    }
}
