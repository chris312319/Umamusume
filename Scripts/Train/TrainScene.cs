using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainScene : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ChooseState,TrainState;
    static public int StateNum = 1,ChooseUma = 0;
    void Start()
    {
        ChooseState = GameObject.Find("ChooseState");
        TrainState = GameObject.Find("TrainState");
        ChooseState.SetActive(false);
        TrainState.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(StateNum == 1)
        {
            ChooseState.SetActive(true);
        }
        if(StateNum == 2)
        {
            ChooseState.SetActive(false);
            TrainState.SetActive(true);
        }
    }
}
