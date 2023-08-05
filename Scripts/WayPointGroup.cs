using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointGroup : MonoBehaviour
{
    [SerializeField] PathPointer PathPointer;
    [SerializeField] Scooter Scooter;

    List<Transform> children;
    public GameObject FirstChild;

    void Update()
    {
        if (Scooter.ChildCountBool)
        {
            children = GetChildren(transform);
            Scooter.WayPointCount= children.Count;
        }

        if (Scooter.TurnOnNextWayPointBool && PathPointer.WayPointCount <= children.Count)
        {
            children[PathPointer.WayPointCount - 1].gameObject.SetActive(false);
            children[PathPointer.WayPointCount].gameObject.SetActive(true);
            Debug.Log("Way Point Count : " + PathPointer.WayPointCount);
            Debug.Log("Next Way Point : " + children[PathPointer.WayPointCount]);
            Scooter.TurnOnNextWayPointBool = false;
        }
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
    }
}
