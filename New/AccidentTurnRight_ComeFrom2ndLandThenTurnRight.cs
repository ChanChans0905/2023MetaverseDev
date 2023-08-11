using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentTurnRight_ComeFrom2ndLandThenTurnRight : MonoBehaviour
{
    public GameObject TurnHelper;
    public Vector3 Velocity2;
    public float Overtake;
    int StoppingDistance;
    Vector3 ParentPositon;
    float Distance;
    public Transform Scooter;
    float TurnHelperPosition;

    Vector3 ES_Velocity;
    Vector3 CarVelocity;
    bool CheckAxis;
    bool ForwardAxis_X;
    


    private void Start()
    {
        StoppingDistance = 60;
        CheckAxis = true;
    }

    private void FixedUpdate()
    {
        ES_Velocity = Scooter.GetComponent<Rigidbody>().velocity;

        if (CheckAxis)
        {
            CarVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            ParentPositon = transform.parent.position;
            if (Mathf.Abs(ParentPositon.x - Scooter.position.x) > Mathf.Abs(ParentPositon.z - Scooter.position.z))
            {
                ForwardAxis_X = true;
            }

            TurnHelperPosition = -15.5f;

            CheckAxis = false;
        }


        if (ForwardAxis_X)
        {
            // 스쿠터의 x 속도 = 차의 z 속도
            ES_Velocity.z = 0;
        }
        else
        {
            // 스쿠터의 z 속도 = 차의 z 속도
            ES_Velocity.x = 0;
            CarVelocity.z = -Mathf.Abs(ES_Velocity.z);
        }

        if (transform.localPosition.z > 35)
        {
            CarVelocity.x = -(ES_Velocity.x);
        }


        if (transform.localPosition.z <= 35 && transform.localPosition.x <= -100)
        {
            TurnHelperPosition -= Time.deltaTime * 0.0001f;
            transform.position = Vector3.MoveTowards(transform.position, TurnHelper.transform.position, 0.1f);
            transform.LookAt(TurnHelper.transform);
            TurnHelper.transform.localPosition = new Vector3(TurnHelperPosition, -29, 15.5f);
            Debug.Log("B");
        }

        if (transform.localPosition.z <= 60 && transform.localPosition.z >= 40)
        {
            Debug.Log("C");
            CarVelocity.x *= 1.2f;
            CarVelocity.z -= 2f;
        }

        if (transform.localPosition.x <= -100)
        {
            CarVelocity.x *= 2f;
            Debug.Log("D");
        }


        // apply the velocity to the car
        gameObject.GetComponent<Rigidbody>().velocity = CarVelocity;
    }
}
