using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointerZoneGroup : MonoBehaviour
{
    [SerializeField] PathPointer PathPointer;
    [SerializeField] Scooter Scooter;

    List<Transform> children;

    void Update()
    {
        if (Scooter.ChildCountBool)
        {
            children = GetChildren(transform);
            Scooter.PathPointerZoneCount = children.Count;
            Scooter.ChildCountBool = false;
        }

        if (Scooter.TurnOnNextPathPointerZoneBool && PathPointer.TargetNameCount <= children.Count)
        {
            children[PathPointer.TargetNameCount -1].gameObject.SetActive(false);
            children[PathPointer.TargetNameCount].gameObject.SetActive(true);
            Debug.Log("Next Path Pointer Zone : " + children[PathPointer.TargetNameCount]);
            Scooter.TurnOnNextPathPointerZoneBool = false;
            PathPointer.ChangeTarget = true;
        }
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
    }
}
