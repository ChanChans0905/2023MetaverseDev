using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentGroup : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    [SerializeField] AccidentPathWay_TurnRightThenStop TurnRightThenStop;
    [SerializeField] AccidentPathWay_SuddenStartFrom3rdLane SuddenStart;

    List<Transform> AccidentList;

    GameObject Accident;
    float SetNextAccidentTimer;
    int[] AccidentOccur = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 };

    void Update()
    {
        if (ES.ChildCountBool)
        {
            AccidentList = GetChildren(transform);
            ShuffleArray(AccidentOccur);
        }

        if (ES.RouteChoice)
        {
            if (ES.ChangeAccident == false)
            {
                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 4)].gameObject;
                else
                    Accident = AccidentList[Random.Range(4, 9)].gameObject;

                Accident.SetActive(true);
                ES.ChangeAccident = true;
            }

        }

        if (ES.SetNextAccident && ES.PathZoneCount < 10)
        {
            SetNextAccidentTimer += Time.deltaTime;
            if (SetNextAccidentTimer > 15)
            {
                ES.distanceTravelled = 0;
                TurnRightThenStop.StoppingTimer= 0;
                SuddenStart.Start = false;

                transform.position = GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount).ToString()).transform.position;
                transform.LookAt(GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1).ToString()).transform.position);
                GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1)).SetActive(false);

                ES.ScooterExitZone = false;
                ES.ScooterEnterAccidentCollidor = false;

                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 4)].gameObject;
                else
                    Accident = AccidentList[Random.Range(4, 9)].gameObject;

                //if (AccidentOccur[ES.PathZoneCount] == 1)
                    Accident.SetActive(true);

                SetNextAccidentTimer = 0;
                ES.SetNextAccident = false;
            }
        }

        if (ES.RespawnTrigger)
        {
            SetNextAccidentTimer = 0;
            Accident.SetActive(false);
        }
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
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
}
