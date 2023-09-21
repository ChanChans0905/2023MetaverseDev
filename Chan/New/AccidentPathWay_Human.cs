using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_Human : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Human;
    float Timer;

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
        ES.distanceTravelled += Time.deltaTime * 10f;
        Timer += Time.deltaTime;

        Human.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Human.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
