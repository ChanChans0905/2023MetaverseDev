using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu_Bus : MonoBehaviour
{
    [SerializeField] SafetyEdu SE;
    public PathCreator pathCreator;
    public GameObject Bus;
    float DistanceTravelled;
    float Timer;

    void Update()
    {
        if (SE.Hit)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if(Timer > 9)
            {
                DistanceTravelled += Time.deltaTime * 0f;
            }

            if (Timer > 25)
            {
                SE.Hit = false;
                Timer = 0;
                DistanceTravelled = 0;
                gameObject.SetActive(false);
            }

            Bus.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 25f);
            Bus.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 25f);
        }
    }
}
