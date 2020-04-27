using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival{

    public Kinematics character;
    public GameObject target;

    public float maxAccel = 20f;
    public float maxSpeed = 5f;

    public float targetRad = 1.5f;
    public float slowRad = 3f;

    public float timeToTarget = 0.1f;

    public Vector3 direction;
    public float distance;

    public virtual SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        direction = target.transform.position - character.transform.position;

        distance = direction.magnitude;

         if(distance < targetRad)
        {
            character.linearVel = Vector3.zero;
            character.angularVel = 0;
            return null;
        }

        float targetSpeed = 0f;
        if (distance > slowRad)
        {
            targetSpeed = maxSpeed;
        }
        else
        {
            targetSpeed = maxSpeed * (distance - targetRad) / targetRad;
        }

        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        result.linear = targetVelocity - character.linearVel;
        result.linear /= timeToTarget;

        if(result.linear.magnitude > maxAccel)
        {
            result.linear.Normalize();
            result.linear *= maxAccel;
        }

        result.angular = 0;
        return result;
    }
}
