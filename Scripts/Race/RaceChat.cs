using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceChat : MonoBehaviour
{
    static public GameObject RC;
    static public GameObject C;
    static public GameObject RoomC;
    static public bool ReturnB = false;
    // Start is called before the first frame update
    void Start()
    {
        RC = GameObject.Find("RaceChat");
        C = GameObject.Find("RaceC");
        RoomC = GameObject.Find("RoomCount");
        RC.SetActive(false);
        RoomC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RC.SetActive(false);
            ReturnB = true;
        }
    }
}
