using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointerZoneGroup : MonoBehaviour
{
    [SerializeField] Scooter Scooter;



    List<Transform> PathZone;
    

    void Update()
    {
        if (Scooter.ChildCountBool)
        {
            PathZone = GetChildren(transform);
            Scooter.PathZoneCount = PathZone.Count;
            Scooter.ChildCountBool = false;
        }

        // ���� ���� bool �ɸ��� ù��° zone �ѳ���, �����Ͱ� zone�� OnTriggerEnter�� ������ ���� Zone Ű�� ������̼� ����

        if (Scooter.TurnOnNextPathZone) // && pathzonecount ���� �۾ƾ� ��, ���� ����
        {
            PathZone[Scooter.NextPathZone].gameObject.SetActive(true);
            Scooter.TurnOnNextPathZone = false;
            Scooter.LookAtNextPathZone = true;
        }




        //if (Scooter.TurnOnNextPathPointerZoneBool && PathPointer.TargetNameCount <= children.Count)
        //{
        //    children[PathPointer.TargetNameCount].gameObject.SetActive(true);

        //    Debug.Log("Next Path Pointer Zone : " + children[PathPointer.TargetNameCount]);
        //    Scooter.TurnOnNextPathPointerZoneBool = false;
        //    PathPointer.ChangeTarget = true;
        //}
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
    }
}
