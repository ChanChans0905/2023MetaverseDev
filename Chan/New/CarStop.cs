using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStop : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PathZone")
            ES.Stop = true;
    }
}
