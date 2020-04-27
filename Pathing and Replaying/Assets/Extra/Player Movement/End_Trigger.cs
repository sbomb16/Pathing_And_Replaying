using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Trigger : MonoBehaviour {

    // Instance of the Game_Manager script
    public Game_Manager gameManager;

    // This function is called when the Player object enters a trigger area
    void OnTriggerEnter(Collider other)
    {

        // Checks to see if the active scene is Wander_Boy
        if(SceneManager.GetActiveScene().name == "Dynamic_Movement")
        {

            SceneManager.LoadScene(0);
            // Calls the EndGame fucntion in the End_Game script
            //gameManager.Exit_Game();

        }
        // If the active scene isnt Wander_Boy, do this instead
        //else
        //{

        //    // Calls the CompleteLevel function in the Game_Manager script
        //    gameManager.CompleteLevel();

        //}        
    }
}
