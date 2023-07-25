using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AccidentTriggerZone : MonoBehaviour
{

    [SerializeField] Scooter Scooter;
    public GameObject Obstacle;
    public bool AccidentTrigger;
    public PathCreator pathCreator;
    float distanceTravelled;
    float disableTime;
    int TriggerNumber;
    char LastChar;

    private void Start()
    {
        // Get the last letter of the object's name to give the value in order 
        LastChar = (gameObject.name[gameObject.name.Length - 1]);
        TriggerNumber = int.Parse(LastChar.ToString()); 
    }

    void Update()
    {
        if (AccidentTrigger == true && Scooter.AccidentTrigger[TriggerNumber] == 1)
        {
            Obstacle.SetActive(true);
            distanceTravelled += Time.deltaTime * 1;
            Obstacle.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            Obstacle.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
            
            // disable the obstacle and reset it
            disableTime += Time.deltaTime;
            if (disableTime > 10)
            {
                distanceTravelled = 0;
                disableTime = 0;
                Obstacle.SetActive(false);
                AccidentTrigger = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scooter"))
        {
            AccidentTrigger = true;
        }
    }
}
