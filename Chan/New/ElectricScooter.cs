using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricScooter : MonoBehaviour
{

    public GameObject PathPointer;
    public GameObject AccidentGroup;
    public GameObject FailureNotice, GameEndNotice;
    public GameObject PathZoneGroup_1, PathZoneGroup_2, PathZoneGroup_3;
    public GameObject PathZone_1_0, PathZone_2_0, PathZone_3_0;

    public int PathZoneCount;
    public int RouteSelection;
    public float distanceTravelled;
    float RouteChoiceTimer, OnTriggerThreshold, RespawnTimer;

    public bool ChildCountBool, TurnOnNextPathZone, LookAtNextPathZone;
    public bool MainTask, RouteChoice, RespawnTrigger;
    public bool StraightOrTurnRight, SetNextAccident, ChangeAccident;
    public bool ScooterExitZone, ScooterEnterZone, ScooterEnterAccidentCollidor;

    public GameObject Restart;
    public GameObject Finish;
    public GameObject Player; 

    public string PathZoneName = "PathZone";
    string AccidentStraight = "AccidentStraight";
    string AccidentTurnRight = "AccidentTurnRight";
    bool GameEndBool;
    public bool Stop;

    GameObject FindTargetZone;
    Vector3 TargetZone, AccidentGroupStartPosition, ScooterStartPosition;
    Quaternion AccidentGroupStartRotation, ScooterStartRotation;

    string[] Route_StraightOrTurnRight = new string[10];
    string[] AccidentScenario_Straight = new string[] { "StraightThenStopOn3rdLane", "TurnRight", "SuddenStartFrom3rdLane" };
    string[] AccidentScenario_TurnRight = new string[] { "TurnRightThenStop", "ComeFrom2ndLandThenTurnRight", "StraightThenStopOn3rdLane", "SuddenStartFrom3rdLane" };

    private void Start()
    {
        RespawnTrigger = false; 
    }

    void Update()
    {

        if (RouteChoice)
        {

            ChildCountBool = true;
            RouteChoiceTimer += Time.deltaTime;

            if (RouteSelection == 1)
            {
                PathZoneGroup_1.SetActive(true);
                PathZone_1_0.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "Straight", "Straight", "TurnRight", "Straight", "TurnRight", "Straight", "Straight", "TurnRight", "TurnRight", "TurnRight" };
            }
            else if (RouteSelection == 2)
            {
                PathZoneGroup_2.SetActive(true);
                PathZone_2_0.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "TurnRight", "Straight", "TurnRight", "TurnRight", "Straight", "TurnRight", "Straight", "Straight", "TurnRight", "TurnRight" };
            }
            else if (RouteSelection == 3)
            {
                PathZoneGroup_3.SetActive(true);
                PathZone_3_0.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "TurnRight", "Straight", "TurnRight", "Straight", "TurnRight", "Straight", "TurnRight", "TurnRight", "Straight", "TurnRight" };
            }

            if (Route_StraightOrTurnRight[PathZoneCount] == "Straight")
                StraightOrTurnRight = true;
            else if (Route_StraightOrTurnRight[PathZoneCount] == "TurnRight")
                StraightOrTurnRight = false;

            AccidentGroupStartPosition = AccidentGroup.transform.position;
            AccidentGroupStartRotation = AccidentGroup.transform.rotation;
            ScooterStartPosition = new Vector3(995, 0, -935);//transform.position;
            ScooterStartRotation = Quaternion.Euler(0, -90, 0); //transform.rotation;

            LookAtNextPathZone = true;

            if (RouteChoiceTimer > 3)
            {
                RouteChoice = false;
                MainTask = true;
                ChildCountBool = false;
                RouteChoiceTimer = 0;
                ChangeAccident = false;
            }
        }

        if (MainTask)
        {
            if (OnTriggerThreshold <= 3)
                OnTriggerThreshold += Time.deltaTime;

            TargetZone = FindTargetZone.transform.position;
            Vector3 direction = TargetZone - PathPointer.transform.position;
            direction.y = 2.5f;

            Quaternion rotTarget = Quaternion.LookRotation(TargetZone - PathPointer.transform.position);
            PathPointer.transform.rotation = Quaternion.RotateTowards(PathPointer.transform.rotation, rotTarget, 20 * Time.deltaTime);

        }

        if (LookAtNextPathZone)
        {
            FindTargetZone = GameObject.Find(PathZoneName + "_" + RouteSelection.ToString() + "_" + PathZoneCount.ToString());
            LookAtNextPathZone = false;
        }

        if (SetNextAccident && PathZoneCount < 10)
        {
            if (Route_StraightOrTurnRight[PathZoneCount] == "Straight")
                StraightOrTurnRight = true;
            else if (Route_StraightOrTurnRight[PathZoneCount] == "TurnRight")
                StraightOrTurnRight = false;


            Stop = false;
        }

        if (RespawnTrigger) 
            Respawn();
        if(GameEndBool)
            GameEnd();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            RespawnTrigger = true;
            FailureNotice.SetActive(true);
        }

        if (other.gameObject.CompareTag("EndPoint"))
        {
            RespawnTrigger = true;
            GameEndBool = true;
        }

        if (other.gameObject.CompareTag("PathZone"))
        {
            if (OnTriggerThreshold >= 2)
            {
                ScooterEnterZone = true;
                PathZoneCount++;
                TurnOnNextPathZone = true;
                OnTriggerThreshold = 0;
            }
        }
        if (other.gameObject.CompareTag("AccidentCollidor"))
            ScooterEnterAccidentCollidor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PathZone"))
        {
            SetNextAccident = true;
            ScooterExitZone = true;
        }
    }



    public void Respawn()
    {
        RespawnTimer += Time.deltaTime;
        transform.position = ScooterStartPosition;
        transform.rotation = ScooterStartRotation;
        AccidentGroup.transform.position = AccidentGroupStartPosition;
        AccidentGroup.transform.rotation = AccidentGroupStartRotation;
        PathZoneCount = 0;
        RouteSelection = 0;
        OnTriggerThreshold = 0;
        MainTask = false;

        PathZoneGroup_1.SetActive(false);
        PathZoneGroup_2.SetActive(false);
        PathZoneGroup_3.SetActive(false);

        Player.transform.position = ScooterStartPosition;
        Player.transform.rotation = ScooterStartRotation; 
        RespawnTrigger = false;
        RespawnTimer = 0;
        gameObject.SetActive(false);

    }

    public void GameEnd()
    {

        GameEndNotice.SetActive(true);
        GameEndBool = false;
    }
}
