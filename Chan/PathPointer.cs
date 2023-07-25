using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointer : MonoBehaviour
{
    [SerializeField] TurnOnNextPathPointer TurnOnNextPathPointer;
    [SerializeField] Scooter Scooter;
    Vector3 TG2;
    GameObject TG;
    string PathName = "PathPointerZone";
    public int TargetNameCount;
    public bool ChangeTarget;

    void Update()
    {
        if (ChangeTarget)
        {
            TG = GameObject.Find(PathName + 1.ToString() + "_" + TargetNameCount.ToString());
            ChangeTarget = false;
        }

        if (Input.GetKey(KeyCode.P)) Scooter.MainTask = true;

        if (Scooter.MainTask)
        {
            TG2 = TG.transform.position;
            transform.LookAt(TG2);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathPointer"))
        {
            if(TargetNameCount <= TurnOnNextPathPointer.ChildCount)
            {
                TargetNameCount++;
                TurnOnNextPathPointer.TurnOnNextPathPointerBool = true;
                ChangeTarget = true;
            }
        }
    }
}
