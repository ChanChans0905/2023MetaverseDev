using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : MonoBehaviour
{

    [SerializeField] FadeInOut FadeInOut;
    [SerializeField] PathPointer PathPointer;
    [SerializeField] TurnOnNextPathPointer TurnOnNextPathPointer;

    public int[] AccidentTrigger = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 }; // 1 : Event occurs, 0 : Nothing happens
    public GameObject AccidentGroup1, AccidentGroup2, AccidentGroup3, PathPointerZoneGroup1, PathPointerZoneGroup2, PathPointerZoneGroup3, GameEndNotice;
    public bool RespawnTrigger, AccidentActivateBool1, AccidentActivateBool2, AccidentActivateBool3;
    public bool RouteChoice, MainTask, GameEndBool;

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            AccidentActivateBool1 = true;
            RouteChoice = true;
        }

        if(RouteChoice)
        {
            // Activate chosen route's accident group
            if (AccidentActivateBool1)
            {
                AccidentGroup1.SetActive(true);
                PathPointerZoneGroup1.SetActive(true);

            }
            else if (AccidentActivateBool2)
            {
                AccidentGroup2.SetActive(true);
                PathPointerZoneGroup2.SetActive(true);
            }
            else if (AccidentActivateBool3)
            {
                AccidentGroup3.SetActive(true);
                PathPointerZoneGroup3.SetActive(true);
            }

            TurnOnNextPathPointer.ChildCountBool = true;
            PathPointer.ChangeTarget = true;
            // shuffle the event triiger
            ShuffleArray(AccidentTrigger);
            
            RouteChoice = false;
        }

        if (GameEndBool) GameEnd();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the scooter collides with the car or human
        if (other.gameObject.CompareTag("Obstacle"))
        {
            FadeInOut.FadingEvent = true;
            FadeInOut.FadingTimer = 0;
        }

        // if the game is finished, reset the event objects
        if (other.gameObject.CompareTag("EndPoint"))
        {
            GameEndBool = true;
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
        AccidentGroup1.SetActive(false);
        AccidentGroup2.SetActive(false);
        AccidentGroup3.SetActive(false);
        PathPointerZoneGroup1.SetActive(false);
        PathPointerZoneGroup2.SetActive(false);
        PathPointerZoneGroup3.SetActive(false);
        AccidentActivateBool1 = false;
        AccidentActivateBool2 = false;
        AccidentActivateBool3 = false;

        PathPointer.TargetNameCount = 0;

        FadeInOut.FadingEvent = true;
        FadeInOut.FadingTimer = 0;

        GameEndNotice.SetActive(true);
        GameEndBool = false;
    }

}
