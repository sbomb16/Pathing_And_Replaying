using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Counter : MonoBehaviour {

    public Text keys;
    public Player_Movement keyCount;
    Key_Counter instance;
    Text keyText;
    GameObject foundText;
    GameObject escapeText;

    public int keysFound = 0;

    private void Start()
    {
        instance = this;

        keyText = keys.GetComponent<Text>();
        foundText = GameObject.Find("Keys text");
        escapeText = GameObject.Find("All Keys Found");

        //keyCount = GetComponent<Player_Movement>();

        escapeText.SetActive(false);

        //keys = keyText.GetComponent<Text>();
        keys.text = keyCount.keysCollected.ToString();

    }

    private void Update()
    {
        int keysCounted = keyCount.keysCollected;
        if(keys != null)
        {
            keys.text = keysCounted.ToString();
            if (keysCounted == 4)
            {
                Destroy(keyText);
                foundText.SetActive(false);
                escapeText.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Whoops lol");
        }
        
    }
}
