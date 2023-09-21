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

        // 게임 시작 bool 걸리면 첫번째 zone 켜놓고, 스쿠터가 zone에 OnTriggerEnter할 때마다 다음 Zone 키고 내비게이션 변경

        if (Scooter.TurnOnNextPathZone) // && pathzonecount 보다 작아야 함, 오류 방지
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
