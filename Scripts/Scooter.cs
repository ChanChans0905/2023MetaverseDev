using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : MonoBehaviour
{

    [SerializeField] FadeInOut FadeInOut;
    [SerializeField] PathPointer PathPointer;

    public int[] AccidentTrigger = new int[13]; // 1 : Event occurs, 0 : Nothing happens
    public GameObject AccidentGroup1, AccidentGroup2, AccidentGroup3, PathPointerZoneGroup1, PathPointerZoneGroup2, PathPointerZoneGroup3, GameEndNotice, FailureNotice;
    public bool RespawnTrigger, GameEndBool, TurnOnSafetyExample;
    public bool RouteChoice, MainTask, ChildCountBool, TurnOnNextPathPointerZoneBool, TurnOnNextWayPointBool;
    public int MainTaskSelection, PathPointerZoneCount, WayPointCount;
    float Timer;
    int Button_A;

    public GameObject SafetyExample1, SafetyExample2, SafetyExample3;

    Vector3 Position = new Vector3(0, 180, 0);

    void Update()
    {
        // Select Route by Clicking the box
        if(Input.GetKeyUp(KeyCode.O))
        {
            FadeInOut.FadingEvent = false;
            RespawnTrigger = true;
            MainTaskSelection = 1;
            RouteChoice = true;
        }



        if (Button_A == 1)
        {
            SafetyExample1.SetActive(true);
            TurnOnSafetyExample = true;
        }
        if (Button_A == 2)
        {
            SafetyExample1.SetActive(false);
            SafetyExample2.SetActive(true);
        }
        if (Button_A == 3)
        {
            SafetyExample2.SetActive(false);
            SafetyExample3.SetActive(true);
        }
        if (Button_A == 4)
        {
            SafetyExample3.SetActive(false);
            TurnOnSafetyExample = false;
        }

        if(RouteChoice)
        {
            // Activate chosen route's accident group
            if (MainTaskSelection == 1)
            {
                AccidentGroup1.SetActive(true);
                PathPointerZoneGroup1.SetActive(true);

            }
            else if (MainTaskSelection == 2)
            {
                AccidentGroup2.SetActive(true);
                PathPointerZoneGroup2.SetActive(true);
            }
            else if (MainTaskSelection == 3)
            {
                AccidentGroup3.SetActive(true);
                PathPointerZoneGroup3.SetActive(true);
            }

            ChildCountBool = true;
            PathPointer.ChangeTarget = true;
            // shuffle the event triiger
            //ShuffleArray(AccidentTrigger);
            
            MainTask = true;
            RouteChoice = false;
        }

        if (GameEndBool) GameEnd();
        if(RespawnTrigger) Respawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the scooter collides with the car or human
        if (other.gameObject.CompareTag("Obstacle"))
        {
            FadeInOut.FadingEvent = true;
            RespawnTrigger = true;
            FailureNotice.SetActive(true);
        }

        // if the game is finished, reset the event objects
        if (other.gameObject.CompareTag("EndPoint"))
        {
            RespawnTrigger = true;
            FadeInOut.FadingEvent = true;
            GameEndBool = true;
        }

        if (other.CompareTag("PathPointer"))
        {
            if (PathPointer.TargetNameCount <= PathPointerZoneCount)
            {
                PathPointer.TargetNameCount++;
                TurnOnNextPathPointerZoneBool = true;
                PathPointer.ChangeTarget = true;
            }
        }

        if (other.gameObject.CompareTag("WayPoint"))
        {
            WayPointCount++;
        }
    }


    // Shuffle the List
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

    public void GameEnd()
    {
        PathPointerZoneGroup1.SetActive(false);
        PathPointerZoneGroup2.SetActive(false);
        PathPointerZoneGroup3.SetActive(false);
        MainTaskSelection = 0;

        PathPointer.TargetNameCount = 0;

        GameEndNotice.SetActive(true);
        GameEndBool = false;
    }

    public void Respawn()
    {
        Timer += Time.deltaTime;
        transform.position = new Vector3 (6,2.25f,17);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Position), 0.5f * Time.deltaTime);
        FadeInOut.Fade();

        if (Timer >= 7)
        {
            RespawnTrigger = false;
            Timer = 0;
        }
    }
}
