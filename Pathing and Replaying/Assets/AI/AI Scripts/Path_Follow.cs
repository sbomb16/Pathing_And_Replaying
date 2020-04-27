using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Follow : Arrival
{

    public GameObject[] path;

    float targetChangeRad = 2f;
    public int currTarIndex;

    int randTarget;
    //public bool reset = true;


    public override SteeringOutput GetSteering()
    {
        
        if (target == null)
        {
            //Debug.Log(currTarIndex);
            currTarIndex = 0;
            target = path[0];
        }

        //Debug.Log(currTarIndex);
        //Debug.Log(target);
        //Debug.Log(path[0]);

        Vector3 vectToTarget = target.transform.position - character.transform.position;
        float distToTarget = vectToTarget.magnitude;

        //Debug.Log(distToTarget);

        if (distToTarget < targetChangeRad)
        {
            if(path.Length == 10)
            {
                switch (currTarIndex)
                {
                    case 0:
                        randTarget = Random.Range(3, 6);
                        if (randTarget >= 5)
                        {
                            currTarIndex = 6;
                        }
                        else
                        {
                            currTarIndex = 3;
                        }
                        break;

                    case 1:
                        randTarget = Random.Range(2, 5);
                        if (randTarget >= 4)
                        {
                            currTarIndex = 5;
                        }
                        else
                        {
                            currTarIndex = 2;
                        }
                        break;

                    case 2:
                        randTarget = Random.Range(1, 7);
                        if (randTarget >= 4)
                        {
                            currTarIndex = 7;
                        }
                        else
                        {
                            currTarIndex = 1;
                        }
                        break;

                    case 3:
                        randTarget = Random.Range(0, 4);
                        if (randTarget >= 2)
                        {
                            currTarIndex = 4;
                        }
                        else
                        {
                            currTarIndex = 0;
                        }
                        break;
                    case 4:
                        randTarget = Random.Range(3, 9);
                        if (randTarget <= 4)
                        {
                            currTarIndex = 3;
                        }
                        else if (randTarget >= 8)
                        {
                            currTarIndex = 5;
                        }
                        else
                        {
                            currTarIndex = 9;
                        }
                        break;

                    case 5:
                        randTarget = Random.Range(1, 8);
                        if (randTarget <= 2)
                        {
                            currTarIndex = 1;
                        }
                        else if (randTarget >= 7)
                        {
                            currTarIndex = 4;
                        }
                        else
                        {
                            currTarIndex = 8;
                        }
                        break;
                    case 6:
                        randTarget = Random.Range(0, 9);
                        if (randTarget <= 3)
                        {
                            currTarIndex = 0;
                        }
                        else if (randTarget >= 7)
                        {
                            currTarIndex = 7;
                        }
                        else
                        {
                            currTarIndex = 9;
                        }
                        break;

                    case 7:
                        randTarget = Random.Range(2, 8);
                        if (randTarget <= 3)
                        {
                            currTarIndex = 2;
                        }
                        else if (randTarget >= 7)
                        {
                            currTarIndex = 6;
                        }
                        else
                        {
                            currTarIndex = 8;
                        }
                        break;

                    case 8:
                        randTarget = Random.Range(5, 9);
                        if (randTarget <= 6)
                        {
                            currTarIndex = 5;
                        }
                        else if (randTarget >= 8)
                        {
                            currTarIndex = 7;
                        }
                        else
                        {
                            currTarIndex = 9;
                        }
                        break;

                    case 9:
                        randTarget = Random.Range(4, 8);
                        if (randTarget <= 5)
                        {
                            currTarIndex = 4;
                        }
                        else if (randTarget >= 7)
                        {
                            currTarIndex = 6;
                        }
                        else
                        {
                            currTarIndex = 8;
                        }
                        break;

                    default:
                        currTarIndex = 0;
                        break;

                }
            } else
            {
                currTarIndex++;

                if (currTarIndex > path.Length - 1)
                {
                    //Debug.Log("I shouldnt be in here yet");
                    currTarIndex = 0;
                }
                Debug.Log(currTarIndex);
            }
        }

        target = path[currTarIndex];

        //Debug.Log(target);

        return base.GetSteering();

    }
}
