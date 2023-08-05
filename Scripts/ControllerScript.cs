using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject L_hand;
    [SerializeField] private GameObject R_hand;

    private void Start()
    {
        float prev_rot = R_hand.transform.localEulerAngles.y;

    }
    void Update()
    {
        float curr_rot = R_hand.transform.localEulerAngles.y;


    }
}