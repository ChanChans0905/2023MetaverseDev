using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu_Human : MonoBehaviour
{
    [SerializeField] SafetyEdu SE;
    public PathCreator pathCreator;
    public GameObject Human;
    float DistanceTravelled;
    float Timer;

    void Update()
    {
        if (SE.Human)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            Human.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 7f);

            if (Timer > 15)
            {
                SE.Human= false;
                Timer = 0;
                DistanceTravelled = 0;
                Human.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
