using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_SuddenStartFrom3rdLane : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Car;
    public bool Start;
    float Timer;

    void Update()
    {
        NormalDrive();

        if (Timer > 15)
        {
            Timer = 0;
            gameObject.SetActive(false);
        }
    }

    void NormalDrive()
    {
        if (ES.ScooterExitZone)
            Start = true;

        if (Start)
        {
            ES.distanceTravelled += Time.deltaTime * 10f;
            Timer += Time.deltaTime;
        }
            

        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
