using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_ComeFrom2ndLaneThenTurnRight : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Car;
    float Timer;

    // Update is called once per frame
    void Update()
    {
        if (ES.ScooterEnterAccidentCollidor) NormalDrive();

        if(Timer > 15)
        {
            Timer = 0;
            gameObject.SetActive(false);
        }
    }

    void NormalDrive()
    {
        ES.distanceTravelled += Time.deltaTime * 20f;
        Timer += Time.deltaTime;

        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
