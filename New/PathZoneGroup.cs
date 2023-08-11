using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathZoneGroup : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;

    List<Transform> PathZone;

    void Update()
    {
        if (ES.ChildCountBool)
        {
            PathZone = GetChildren(transform);
        }

        if (ES.TurnOnNextPathZone)
        {
            PathZone[ES.PathZoneCount].gameObject.SetActive(true);
            ES.LookAtNextPathZone = true;
            ES.TurnOnNextPathZone = false;
        }

        List<Transform> GetChildren(Transform parent)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in parent) { children.Add(child); }
            return children;
        }

        if(ES.RespawnTrigger)
            for(int i = 1; i < PathZone.Count; i++)
                PathZone[i].gameObject.SetActive(false); 
    }
}
