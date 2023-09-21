using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu_LaneChanging : MonoBehaviour
{
    [SerializeField] SafetyEdu SE;
    public PathCreator pathCreator;
    public GameObject Car;
    float DistanceTravelled;
    float Timer;

    void Update()
    {
        if (SE.LaneChanging)
        {
            Car.SetActive(true);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            Car.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 16f);
            Car.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 16f);

            if (Timer > 40)
            {
                SE.LaneChanging = false;
                Timer = 0;
                DistanceTravelled = 0;
                Car.SetActive (false);
                gameObject.SetActive(false);
            }
        }
    }
}
