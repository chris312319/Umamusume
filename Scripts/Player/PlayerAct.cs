using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class PlayerAct : MonoBehaviour
    {
    float speed = 5f;　　//移动速度
    private CharacterController characterController;
    private float h;
    private float v;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        dir = new Vector3(h, 0, v);
        //transform.LookAt(transform.position + dir);  
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;//左右移动
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;//前后移动

        Vector3 movement = new Vector3(x, 0, z);
        movement = transform.TransformDirection(movement);//旋转之后的转向

        Vector3 newMovement = new Vector3(movement.x, 0, movement.z);
        characterController.Move(newMovement);//移动
    }
 }