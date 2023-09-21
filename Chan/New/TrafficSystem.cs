using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSystem : MonoBehaviour
{
    public GameObject RedLight_1, RedLight_2, GreenLight_1, GreenLight_2;
    public GameObject Traffic_1, Traffic_2;
    float TrafficTimer;
    bool WhichSide, ChangeTrafficSignalBool;

    private void Start()
    {
        ChangeTrafficSignalBool = true;
    }

    void Update()
    {
        TrafficTimer += Time.deltaTime;

        if(TrafficTimer > 10f)
        {
            ChangeTrafficSignalBool = true;
            TrafficTimer = 0;
        }

        if(ChangeTrafficSignalBool)
            ChangeTrafficSignal();
    }

    void ChangeTrafficSignal()
    {
        if(WhichSide)
        {
            GreenLight_1.SetActive(true);
            GreenLight_2.SetActive(false);
            RedLight_1.SetActive(false);
            RedLight_2.SetActive(true);
            Traffic_1.SetActive(false);
            Traffic_2.SetActive(true);
            WhichSide = false;
            ChangeTrafficSignalBool=false;
        }
        else if(!WhichSide)
        {
            GreenLight_1.SetActive(false);
            GreenLight_2.SetActive(true);
            RedLight_1.SetActive(true);
            RedLight_2.SetActive(false);
            Traffic_1.SetActive(true);
            Traffic_2.SetActive(false);
            WhichSide = true;
            ChangeTrafficSignalBool = false;
        }
    }
}
