using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Variable that represents the Player object's Rigidbody
    public Rigidbody rb;

    // Float that determines the force applied to the Player object on the Z axis
    public float forwardForce = 500f;

    // Float that determines the force applied to the Player object on the X axis
    public float sideForce = 100f;

    // Float that determines how many jumps the Player object has remaining
    //public float jumpsRemaining = 3f;

    public bool doubleJump = false;

    // Vector that contains the variable that determines the force that's applied to the Player object in the positive Y direction 
    public Vector3 jumpHeight = new Vector3(0, 10, 0);

    // Boolean that determines whether the Player object is on the ground or not
    public bool isOnGround = true;

    // Boolean that determines whether the Player object can double jump
    public bool canDoubleJump = false;

    public int keysCollected = 0;

    // This function controls the jumping feature
    void Jumping()
    {

        // Checks to see if the isOnGround boolean is true
        if(isOnGround == true)
        {

            // An impulse force is added in the positive Y direction
            rb.AddForce(jumpHeight, ForceMode.Impulse);

            // Sets the isOnGround boolean to false
            isOnGround = false;

            // Reduces the jumpsRemaining float by 1
            //jumpsRemaining--;

        }

        // Checks to see if the isOnGround boolean is false and if the doubleJump boolean is true
        else if(isOnGround == false && doubleJump == true)
        {

            // An impulse force is added in the positive Y direction
            rb.AddForce(jumpHeight, ForceMode.Impulse);            

            // Sets the doubleJump boolean to false
            doubleJump = false;

        }        
    }

    // Update is called once per frame
    void Update () {

        // Continuously applies a force to the Player object in the positive Z direction using the forwardForce float
        if (Input.GetKey("w"))
        {
            Command MoveForward = new MoveForward(rb, forwardForce);
            //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            Invoker invoker = new Invoker();
            invoker.SetCommand(MoveForward);
            invoker.ExecuteCommmand();
        }

        // Constantly checks to see if the player presses the "d" key
        if (Input.GetKey("d"))
        {

            Command MoveRight = new MoveRight(rb, sideForce);
            // A force is added to the Player object in the positive X direction using the sideForce float
            //rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            Invoker invoker = new Invoker();
            invoker.SetCommand(MoveRight);
            invoker.ExecuteCommmand();

        }

        // Constantly checks to see if the player presses the "a" key 
        if (Input.GetKey("a"))
        {

            // A force is added to the Player object in the negative X direction using the sideForce float
            Command MoveLeft = new MoveLeft(rb, sideForce);
            //MoveLeft.Execute();
            //rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            Invoker invoker = new Invoker();
            invoker.SetCommand(MoveLeft);
            invoker.ExecuteCommmand();

        }

        // Constantly checks to see if the player presses the "s" key
        if (Input.GetKey("s"))
        {

            Command MoveBackwards = new MoveBackwards(rb, forwardForce);
            // A force is added to the Player object in the negative Z direction using the forwardForce float
            //rb.AddForce(0, 0, -forwardForce * Time.deltaTime);

            Invoker invoker = new Invoker();
            invoker.SetCommand(MoveBackwards);
            invoker.ExecuteCommmand();

        }

        // Constantly checks to see if the player has pressed the spacebar and that the jumpsRemaining float is greater than 0
        //if (Input.GetKeyDown("space") && canDoubleJump == false)
        //{

        //    // Calls the Jumping function
        //    Jumping();

        //    // Sets the canDoubleJump boolean to true
        //    canDoubleJump = true;            

        //}

        //// Constantly checks to see if the player has released the spacebar
        //if (Input.GetKeyUp("space"))
        //{

        //    // Sets the canDoubleJump boolean to false
        //    canDoubleJump = false;

        //}


        // Constantly checks to see if the Player object has fallen below -1 on the Y axis
        if(rb.position.y < -5f)
        {

            // Calls the EndGame function from the Game_Manager script
            FindObjectOfType<Game_Manager>().EndGame();

        }        
    }
}
