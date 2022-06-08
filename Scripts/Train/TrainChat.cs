using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainChat : MonoBehaviour
{
    static public GameObject TC;
    static public GameObject C;
    static public bool ReturnB = false;
    // Start is called before the first frame update
    void Start()
    {
        TC = GameObject.Find("TrainChat");
        C = GameObject.Find("TrainC");
        TC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TC.SetActive(false);
            ReturnB = true;
        }
    }
}
