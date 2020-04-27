using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    // Contains the Player object's position
    public Transform player;

    // A vector that determines the offset of the camera that can be edited in the Unity Inspector
    public Vector3 offset;	

    // Update is called once per frame
	void Update () {

        // Applies the Player object's position to the Main camera, which is then offset with the offset Vector3
        transform.position = player.position + offset;

	}   
}
