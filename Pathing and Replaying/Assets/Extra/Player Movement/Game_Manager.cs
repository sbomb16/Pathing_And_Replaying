using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Class manages how the various scenes switch from one another
public class Game_Manager : MonoBehaviour
{

    // Boolean that tracks whether the game should end or not
    bool gameEnded = false;

    bool instantReplay = false;
    GameObject player;

    // Float that determines the delay from when the Player object hits an obstacle to the end level UI fading in
    public float restartDelay = 1f;

    // Instance of the Level Complete UI GameObject
    //public GameObject levelCompleteUI;

    GameObject spawnGoal;

    // When called, this function checks to see if a boolean is true or false to determine the gamestate
    //private void Start()
    //{

    //    GameObject goal = Resources.Load("AI_Goal") as GameObject;

    //    int rand = Random.Range(0, 7);

    //    Debug.Log(rand);

    //    switch (rand)
    //    {
    //        case 0:
    //            spawnGoal = GameObject.Find("Spawn_1");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        case 1:
    //            spawnGoal = GameObject.Find("Spawn_2");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        case 2:
    //            spawnGoal = GameObject.Find("Spawn_3");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        case 3:
    //            spawnGoal = GameObject.Find("Spawn_4");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        case 4:
    //            spawnGoal = GameObject.Find("Spawn_5");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        case 5:
    //            spawnGoal = GameObject.Find("Spawn_6");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        case 6:
    //            spawnGoal = GameObject.Find("Spawn_7");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //        default:
    //            spawnGoal = GameObject.Find("Spawn_1");
    //            Instantiate(goal, spawnGoal.transform.position, spawnGoal.transform.rotation);
    //            break;

    //    }
    //}

        public void Start()
    {
        Player_Movement playerMovement = FindObjectOfType<Player_Movement>();
        player = playerMovement.gameObject;

        if (Command_Log.commands.Count > 0 && Command_Log.doQueue == true)
        {
            instantReplay = true;
            restartDelay = Time.timeSinceLevelLoad;
        }
    }

    public void EndGame()
    {
        
        // Check to see if the gameEnded boolean is true or false
        if(gameEnded == false)
        {

            // If gameEnded is false, set it to true, then invoke the Restart function
            gameEnded = true;
            Invoke("Restart", restartDelay);

        }        
    }

    void Update()
    {
        if (instantReplay)
        {
            RunInstantReplay();
        }    
    }
    // When called, this function will restart the scene
    void Restart()
    {

        // Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // When called, this function will enable the level end UI assets
    /*public void CompleteLevel()
    {

        // Sets the levelCompleteUI GameObject to active
        levelCompleteUI.SetActive(true);

    }*/

    // When called, this function will quit the application
    public void Exit_Game()
    {
        
        // Quits the application
        Application.Quit();

    }

    void RunInstantReplay()
    {
        if(Command_Log.commands.Count == 0)
        {
            return;
        }

        Command command = Command_Log.commands.Peek();
        if(Time.timeSinceLevelLoad >= command.timeStamp)
        {
            command = Command_Log.commands.Dequeue();
            command._player = player.GetComponent<Rigidbody>();
            Invoker invoker = new Invoker();
            invoker.disableLog = true;
            invoker.SetCommand(command);
            invoker.ExecuteCommmand();
        }
    }
}
