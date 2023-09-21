using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousCar : MonoBehaviour
{
    public GameObject Car;
    Vector3 Velocity;
    bool Stop, AlreadyCrossed;
    float StopTimer;
    int Direction;

    private void Start()
    {
        if(transform.rotation.eulerAngles.y == 0)
            Direction = 0;
        else if(transform.rotation.eulerAngles.y == 180)
            Direction = 1;
        else if (transform.rotation.eulerAngles.y == 90)
            Direction = 2;
        else if(transform.rotation.eulerAngles.y == 270)
            Direction = 3;
    }

    void Update()
    {
        if (StopTimer < 2f)
            StopTimer += Time.deltaTime;

        if (StopTimer > 1.5f)
            Stop = false;

        switch (Direction)
        {
            case 0:
                if (!Stop && Velocity.z < 6f)
                    Velocity.z += 0.05f;

                if ((Stop && Velocity.z > 0f) || Velocity.z > 6f) 
                    Velocity.z -= 0.05f;
                break;
            case 1:
                if (!Stop && Velocity.z > -6f)
                    Velocity.z -= 0.05f;

                if ((Stop && Velocity.z < 0f)|| Velocity.z < -6f )
                    Velocity.z += 0.05f;
                break;
            case 2:
                if (!Stop && Velocity.x < 6f)
                    Velocity.x += 0.05f;

                if ((Stop && Velocity.x > 0f)|| Velocity.x > 6f)
                    Velocity.x -= 0.05f;
                break;
            case 3:
                if (!Stop && Velocity.x > -6f)
                    Velocity.x -= 0.05f;

                if ((Stop && Velocity.x < 0f)|| Velocity.x < -6f)
                    Velocity.x += 0.05f;
                break;
        }

        if(AlreadyCrossed)
        {
            switch (Direction)
            {
                case 0:
                    Velocity.z += 0.1f;
                    break;
                case 1:
                    Velocity.z -= 0.1f;
                    break;
                case 2:
                    Velocity.x += 0.1f;
                    break;
                case 3:
                    Velocity.x -= 0.1f;
                    break;
            }
        }

        Car.gameObject.GetComponent<Rigidbody>().velocity =  Velocity;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "TrafficLight" || other.tag == "Car_Rear")
        {
            if (!AlreadyCrossed)
            {
                StopTimer = 0f;
                Stop = true;
            }
        }

        if(other.tag == "PeopleSemaphore")
            AlreadyCrossed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PeopleSemaphore")
            AlreadyCrossed = false;
    }
}
