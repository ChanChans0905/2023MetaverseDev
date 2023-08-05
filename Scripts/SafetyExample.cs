using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyExample : MonoBehaviour
{
    [SerializeField] Scooter Scooter;
    public GameObject Obstacle;
    public PathCreator pathCreator;
    float distanceTravelled;

    // Update is called once per frame
    void Update()
    {
        if (Scooter.TurnOnSafetyExample)
        {
            distanceTravelled += Time.deltaTime * 1.5f;
            Obstacle.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            Obstacle.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }
    }
}
