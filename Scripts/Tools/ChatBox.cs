using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    static public GameObject CB;
    static public GameObject Chat;
    static public bool CBExist = false;
    // Start is called before the first frame update
    void Start()
    {
        CB = GameObject.Find("ChatBox");
        Chat = GameObject.Find("Chat");
        CB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CB.SetActive(false);
            CBExist = false;
        }
    }
}
