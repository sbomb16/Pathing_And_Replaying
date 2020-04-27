using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation
{

    public Kinematics character;
    public GameObject target;

    public Kinematics[] avoid;

    public float maxAccel = .1f;
    public float threshold = 5f;
    public float decay = 2f;
    public float distance;
    float strength;

    public Vector3 direction;      

    public virtual SteeringOutput GetSteering()
    {

        SteeringOutput result = new SteeringOutput();

        if(avoid != null)
        {
            for (int i = 0; i < avoid.Length - 1; i++)
            {

                direction = character.transform.position - avoid[i].transform.position;
                distance = direction.magnitude;

                //Debug.Log(distance);

                if (distance < threshold)
                {

                    strength = Mathf.Min(decay / (distance * distance), maxAccel);

                    Debug.Log(strength);

                    direction.Normalize();
                    result.linear += strength * direction;

                }
                else if (distance > threshold)
                {

                    strength = Mathf.Min(decay / (distance * distance), maxAccel);

                    direction.Normalize();

                    Debug.Log(direction);
                    result.linear -= strength * direction;

                }
            }
        }
        else
        {
            direction = character.transform.position - target.transform.position;
            distance = direction.magnitude;

            //Debug.Log(distance);

            if (distance < threshold)
            {

                strength = Mathf.Min(decay / (distance * distance), maxAccel);

                Debug.Log(strength);

                direction.Normalize();
                result.linear += strength * direction;

            }
            else if (distance > threshold)
            {

                strength = Mathf.Min(decay / (distance * distance), maxAccel);

                direction.Normalize();

                Debug.Log(direction);
                result.linear -= strength * direction;

            }
        }

        return result;

    }
}
