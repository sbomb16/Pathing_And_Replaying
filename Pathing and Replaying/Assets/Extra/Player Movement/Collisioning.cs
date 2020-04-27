using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioning : MonoBehaviour {

    //public GameObject thisGameObject;

    private void OnTriggerEnter(Collider collide)
    {
        Debug.Log("I hit it");
        Debug.Log(collide.tag.ToString());
        if (collide.tag.ToString() == "player")
        {
            DestroyGameObjects();   
        }
    }

    void DestroyGameObjects()
    {
        Destroy(gameObject, 3);
    }
}
