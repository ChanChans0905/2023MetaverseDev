using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed_Camera : MonoBehaviour
{
    [SerializeField] GameObject scooter;
    private float y; 
    private void Start()
    {
        y = gameObject.transform.position.y;  
    }
    // Update is called once per frame
    void Update()
    {
        if (scooter.activeSelf)
        {
            gameObject.transform.position = new Vector3(scooter.transform.position.x, y, scooter.transform.position.z);
        }
    }

}
