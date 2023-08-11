using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentGroup : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;

    List<Transform> AccidentList;
    GameObject Accident;
    float AccidentTimer;

    void Update()
    {
        if (ES.ChildCountBool)
            AccidentList = GetChildren(transform);

        if (ES.RouteChoice)
        {
            if(ES.ChangeAccident == false)
            {
                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 3)].gameObject;
                else
                    Accident = AccidentList[Random.Range(3, 7)].gameObject;

                Accident.SetActive(true);
                ES.ChangeAccident = true;
            }

        }

        if (ES.AccidentTimerStart)
        {
            AccidentTimer += Time.deltaTime;

            if (AccidentTimer > 7)
            {
                Accident.SetActive(false);
                ES.AccidentCar.SetActive(false);

                transform.position = GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount).ToString()).transform.position;
                transform.LookAt(GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1).ToString()).transform.position);

                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 3)].gameObject;
                else
                    Accident = AccidentList[Random.Range(3, 7)].gameObject;

                Accident.SetActive(true);
                AccidentTimer = 0;
                ES.AccidentTimerStart = false;
            }
        }

        if (ES.RespawnTrigger)
        {
            AccidentTimer = 0;
            Accident.SetActive(false);
        }
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
    }
}
