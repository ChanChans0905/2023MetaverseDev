using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu_Truck : MonoBehaviour
{
    [SerializeField] SafetyEdu SE;
    public PathCreator pathCreator;
    public GameObject Truck;
    float DistanceTravelled;
    float Timer;

    void Update()
    {
        if (SE.Truck)
        {
            Truck.SetActive(true);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            Truck.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 17f);
            Truck.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 17f);

            if (Timer > 25)
            {
                SE.Truck = false;
                Timer = 0;
                DistanceTravelled = 0;
                Truck.SetActive (false);
                gameObject.SetActive(false);
            }
        }
    }
}
