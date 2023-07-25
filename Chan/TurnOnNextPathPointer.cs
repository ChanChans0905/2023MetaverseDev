using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnNextPathPointer : MonoBehaviour
{
    [SerializeField] PathPointer PathPointer;
    [SerializeField] Scooter Scooter;
    public bool TurnOnNextPathPointerBool, ChildCountBool;
    public int ChildCount;

    void Start()
    {
        List<Transform> children = GetChildren(transform);
    }

    void Update()
    {
        List<Transform> children = GetChildren(transform);

        if (ChildCountBool)
        {
            ChildCount = children.Count;
            ChildCountBool = false;
        }

        if (TurnOnNextPathPointerBool && PathPointer.TargetNameCount <= children.Count)
        {
            children[PathPointer.TargetNameCount -1].gameObject.SetActive(false);
            children[PathPointer.TargetNameCount].gameObject.SetActive(true);
            Debug.Log(children[PathPointer.TargetNameCount]);
            TurnOnNextPathPointerBool = false;
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
