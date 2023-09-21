using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject Scooter;
    float DistanceTravelled;


    // Update is called once per frame
    void Update()
    {
        DistanceTravelled += Time.deltaTime * 20f;

        if(DistanceTravelled < 10)
        {
            Scooter.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled);
            Scooter.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled);
        }

        //adsf

        if(DistanceTravelled >= 10 && DistanceTravelled < 15)
        {
            // ¼³¸í 2Â÷
        }
    }
}
