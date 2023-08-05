using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class PathPointer : MonoBehaviour
{
    [SerializeField] Scooter Scooter;
    Vector3 TG2;
    GameObject TG;
    string PathName = "PathPointerZone";
    public int TargetNameCount, WayPointCount;
    public bool ChangeTarget;

    void Update()
    {
        if (ChangeTarget)
        {
            TG = GameObject.Find(PathName + 1.ToString() + "_" + TargetNameCount.ToString());
            ChangeTarget = false;
        }

        if (Scooter.MainTask)
        {
            TG2 = TG.transform.position;
            transform.LookAt(TG2);
        }

    }
}
