using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;

    public Text popupText;

    public bool grown = true;

    public float timerTime = 60.0f;

    public float warningTime = 10f;
    public float growTime = 11f;

    public float playerScale = 1f;

    public float camOffsetY = 10f;
    public float camOffsetZ = 6f;

    public doStuff stuff;

    public thirsPerson thirs;

    public GameObject redMenace;

	// Use this for initialization
	void Start () {
        stuff = new doStuff();
        //thirs = new thirsPerson();
	}

    // Update is called once per frame
    void Update() {

        timerTime -= Time.deltaTime;

        timerText.text = timerTime.ToString("n0");

        if (Mathf.Round(timerTime) % warningTime == 0 && grown == false)
        {
            redMenace.transform.localScale = new Vector3(playerScale, 1, playerScale);
            grown = true;
            playerScale++;
            playerScale++;

            //thirs.yDistance = camOffsetY;
            //thirs.zDistance = camOffsetZ;
        }

        if (Mathf.Round(timerTime) == warningTime)
        {
            popupText.text = stuff.Warning().ToString();
        }

        if(Mathf.Round(timerTime) == warningTime - 5)
        {
            Destroy(popupText);
            //player.transform.localScale = new Vector3(1, 1, 1);
            //thirs.yDistance = 5;
            //thirs.zDistance = 3;
        }

        if(Mathf.Round(timerTime) == 1)
        {
            FindObjectOfType<Game_Manager>().EndGame();
        }

        if (Mathf.Round(timerTime) % growTime == 0 && Mathf.Round(timerTime) % warningTime != 0)
        {
            grown = false;
        }
    }
}

public class doStuff: MonoBehaviour
{
    public Text warningText;

    Timer timing;

    private void Start()
    {
        timing = new Timer();
    }

    public string Warning()
    {

        return "Time's almost up! You better hurry, the Red Menace grows stronger";
    }
}