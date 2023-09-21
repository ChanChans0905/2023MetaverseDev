using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu : MonoBehaviour
{
    [SerializeField] TR_Accel_Vis Acc;
    [SerializeField] TR_Brake_Vis Br;
    public PathCreator pathCreator;
    public GameObject Scooter;
    public GameObject GreenLight, RedLight, DeadSound;
    public GameObject Notice_SlowDown, Notice_Truck, Notice_StopOnRed, Notice_Human, Notice_LaneChanging, Notice_Hit, Notice_KeepLane, Notice_DriveOnRed, Sound_Last;
    public bool Truck, Human, LaneChanging, Hit;
    float DistanceTravelled;
    float Timer, Starter;
    bool Start;
    float linear = 1;


    void Update()
    {
        if (Starter < 3)
            Starter += Time.deltaTime;        

        if(Starter > 2)
            Start = true;

        if (Start)
        {
            //Debug.Log("현재 타이머" + Timer)  ;

            if(Timer < 2 && linear < 30)
            {
                Acc.accel_Input = true;
                Timer += Time.deltaTime * linear / 30 ;
                DistanceTravelled += Time.deltaTime * linear / 30;
                linear += 0.1f;
            }

            if (Timer > 2 &&  Timer < 28)
            {
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime;
            }

            if (Timer > 5 && Timer < 10)
                Notice_KeepLane.SetActive(true);

            if (Timer > 10 && Timer < 11)
                Notice_KeepLane.SetActive(false);

            if (Timer >= 24 && Timer < 27)
                Notice_SlowDown.SetActive(true);

            if (Timer >= 28 && Timer < 31) // Car on 3rd Lane
            {
                Timer += Time.deltaTime * 0.3f;
                DistanceTravelled += Time.deltaTime * 0.3f;
            }

            if (Timer >= 31 && Timer < 56) // Truck
            {
                Notice_SlowDown.SetActive(false);
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime;

                if (Timer > 36)
                {
                    Truck = true;
                    Notice_Truck.SetActive(true);
                }
                if (Timer > 41)
                    Notice_Truck.SetActive(false);
            }

            if (Timer > 50 && Timer < 55)
                Notice_StopOnRed.SetActive(true);

            if (Timer >= 56 && Timer < 62) // Stop on Red
            {
                Acc.accel_Input = false;
                Br.brake_Input = true;
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime * 0f;

                if (Timer > 61)
                {
                    RedLight.SetActive(false);
                    GreenLight.SetActive(true);
                }
            }

            if (Timer >= 62 && Timer < 73)
            {
                Acc.accel_Input = true;
                Br.brake_Input = false;
                Notice_StopOnRed.SetActive(false);
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime;

                if (Timer > 65)
                    Human = true;

                if (Timer > 64)
                    Notice_Human.SetActive(true);
            }

            if (Timer >= 70 && Timer < 76) // Human
            {
                Acc.accel_Input = false;
                Br.brake_Input = true;
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime * 0f;
            }

            if (Timer >= 76 && Timer < 93)
            {
                Acc.accel_Input = true;
                Br.brake_Input = false;
                Notice_Human.SetActive(false);
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime;

                if (Timer > 88)
                    LaneChanging = true;

                if (Timer > 88)
                    Notice_LaneChanging.SetActive(true);
            }

            if (Timer >= 93 && Timer < 98) // Lane Changing
            {
                Acc.accel_Input = false;
                Br.brake_Input = true;
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime * 0f;
            }

            if (Timer >= 98 && Timer < 135)
            {
                Acc.accel_Input = true;
                Br.brake_Input = false;
                Notice_LaneChanging.SetActive(false);
                Timer += Time.deltaTime;
                DistanceTravelled += Time.deltaTime;

                if (Timer > 102)
                    Sound_Last.SetActive(true);

                if (Timer > 129)
                {
                    Notice_DriveOnRed.SetActive(true);
                    Hit = true;
                }

            }

            if (Timer >= 134.5f) // Hit
            {
                Notice_DriveOnRed.SetActive(false);
                Notice_Hit.SetActive(true);
                DistanceTravelled += Time.deltaTime * 0f;
            }

            Scooter.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 11f);
            Scooter.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 11f);
        }

    }
}
