using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Where_Going : Align
{

    //public Align getThings;

    public override SteeringOutput GetSteering()
    {
        Vector3 velocity = character.linearVel;

        if (velocity.magnitude == 0)
        {
            character.transform.eulerAngles = new Vector3(0, character.transform.eulerAngles.y, 0);
            return base.GetSteering();
        }

        float angle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
        if (!target)
        {

            return base.GetSteering();

        }
        else
        {

            character.transform.eulerAngles = new Vector3(0, angle, 0);

            return base.GetSteering();

        }        
    }
}
