using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target = null;
    static public int preparetolook = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (preparetolook == 1)
        {
            target = GameObject.FindWithTag("Uma").transform;
            if(target != null) preparetolook = 0;
        }
        GetComponent<Transform>().LookAt(target);
    }
}
