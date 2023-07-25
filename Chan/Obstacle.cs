using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Movement Scooter;

    Rigidbody _rb;
    public PathCreator pathCreator;
    float distanceTravelled;
    bool wayPointTrigger = false;
    float disableTime;
    Vector3 startPos;


    void Start()
    {
    }

    void Update()
    {
        if (wayPointTrigger == true)
        {
            distanceTravelled += Time.deltaTime * 1;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
            disableTime += Time.deltaTime;
            if (disableTime > 20)
            {
                gameObject.SetActive(false);
                disableTime = 0;
                wayPointTrigger = false;
            }
        }
    }
}
