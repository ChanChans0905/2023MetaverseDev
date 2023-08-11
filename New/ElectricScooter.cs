using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricScooter : MonoBehaviour
{
    [SerializeField] FadeInOut FadeInOut;

    public GameObject PathPointer;
    public GameObject AccidentGroup;
    public GameObject FailureNotice;
    public GameObject PathZoneGroup1;
    public GameObject AccidentCar;


    public int PathZoneCount;
    public bool TurnOnNextPathZone;
    public bool LookAtNextPathZone;
    public bool ChildCountBool;
    public bool AccidentCarMovement;
    public bool RespawnTrigger;
    bool GameSuccessBool;
    public bool MainTask;
    public int RouteSelection;
    public bool AccidentTimerStart;
    public bool StraightOrTurnRight;
    public bool RouteChoice;
    public bool ChangeAccident;
    float OnTriggerThreshold;
    public float distanceTravelled;

    float RespawnTimer;
    float RouteChoiceTimer;
    public string PathZoneName = "PathZone";
    string AccidentStraight = "AccidentStraight";
    string AccidentTurnRight = "AccidentTurnRight";
    GameObject FindTargetZone;
    Vector3 TargetZone;
    public Vector3 ES_Location;

    Vector3 AccidentGroupStartPosition;
    Quaternion AccidentGroupStartRotation;
    Vector3 ScooterStartPosition;
    Quaternion ScooterStartRotation;

    string[] Route_StraightOrTurnRight = new string[10];
    int[] AccidentOccur = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
    string[] AccidentScenario_Straight = new string[] { "StraightThenStopOn3rdLane", "TurnRight", "SuddenStartFrom3rdLane" };
    string[] AccidentScenario_TurnRight = new string[] { "TurnRightThenStop", "ComeFrom2ndLandThenTurnRight", "StraightThenStopOn3rdLane", "SuddenStartFrom3rdLane" };
    int[] TotalAccidentScenario = new int[10];

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RouteSelection = 1;
            RouteChoice = true;
        }

        if (RouteChoice)
        {
            ChildCountBool = true;
            RouteChoiceTimer += Time.deltaTime;

            if(RouteSelection == 1)
            {
                PathZoneGroup1.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "Straight", "Straight", "TurnRight", "Straight", "TurnRight", "Straight", "Straight", "TurnRight", "TurnRight", "TurnRight" };
            }

            if (Route_StraightOrTurnRight[PathZoneCount] == "Straight")
                StraightOrTurnRight = true;
            else if (Route_StraightOrTurnRight[PathZoneCount] == "TurnRight")
                StraightOrTurnRight = false;

            AccidentGroupStartPosition = AccidentGroup.transform.position;
            AccidentGroupStartRotation = AccidentGroup.transform.rotation;
            ScooterStartPosition = transform.position;
            ScooterStartRotation = transform.rotation;

            LookAtNextPathZone = true;

            if(RouteChoiceTimer > 3)
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
            if (OnTriggerThreshold <= 6)
                OnTriggerThreshold += Time.deltaTime;

            Vector3 direction = TargetZone - PathPointer.transform.position;
            direction.y = 2.5f;
            Quaternion toRotation = Quaternion.FromToRotation(PathPointer.transform.forward, direction);
            PathPointer.transform.rotation = Quaternion.Lerp(PathPointer.transform.rotation, toRotation, Time.deltaTime);
        }

        if (LookAtNextPathZone)
        {
            FindTargetZone = GameObject.Find(PathZoneName + "_" + RouteSelection.ToString() + "_" + PathZoneCount.ToString());
            TargetZone = FindTargetZone.transform.position;
        }

        if (AccidentTimerStart)
        {
            if (Route_StraightOrTurnRight[PathZoneCount] == "Straight")
                StraightOrTurnRight = true;
            else if (Route_StraightOrTurnRight[PathZoneCount] == "TurnRight")
                StraightOrTurnRight = false;
        }

        if(RespawnTrigger) Respawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            RespawnTrigger = true;
            FadeInOut.FadingEvent = true;
            FailureNotice.SetActive(true);
        }

        if (other.gameObject.CompareTag("EndPoint"))
        {
            RespawnTrigger = true;
            FadeInOut.FadingEvent = true;
            GameSuccessBool = true;
        }

        if (other.gameObject.CompareTag("PathZone"))
        {
            if(OnTriggerThreshold >= 2)
            {
                AccidentCar.SetActive(true);
                AccidentCarMovement = true;
                PathZoneCount++;
                TurnOnNextPathZone = true;
                OnTriggerThreshold = 0;
                distanceTravelled = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PathZone"))
        {
            AccidentTimerStart = true;
            ES_Location = gameObject.transform.position;
        }
    }

    static public T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

    public void Respawn()
    {
        FadeInOut.Fade();
        RespawnTimer += Time.deltaTime;
        transform.position = ScooterStartPosition;
        transform.rotation = ScooterStartRotation;
        AccidentGroup.transform.position = AccidentGroupStartPosition;
        AccidentGroup.transform.rotation = AccidentGroupStartRotation;
        AccidentCar.SetActive(false);

        if (RespawnTimer>= 7)
        {
            RespawnTrigger = false;
            RespawnTimer = 0;
        }
    }
}
