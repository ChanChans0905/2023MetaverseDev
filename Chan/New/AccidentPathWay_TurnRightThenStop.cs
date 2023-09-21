using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_TurnRightThenStop : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public float StoppingTimer;
    public GameObject Car;
    float Timer;

    void Update()
    {
        if (ES.ScooterEnterAccidentCollidor) NormalDrive();

        if (Timer > 15)
        {
            Timer = 0;
            gameObject.SetActive(false);
        }
    }

    void NormalDrive()
    {
        Timer += Time.deltaTime;

        StoppingTimer += Time.deltaTime;
        if (StoppingTimer < 2)
            ES.distanceTravelled += Time.deltaTime * 25f;
        if (!(StoppingTimer >= 5 && StoppingTimer <= 9))
            ES.distanceTravelled += Time.deltaTime * 10f;
        if (StoppingTimer > 10)
            ES.distanceTravelled += Time.deltaTime * 20f;

        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
