using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DormitoryRoom : MonoBehaviour
{
    static public int type, Speed, Energy, Int , Power;
    public GameObject UmaT, UmaP , UmaS, UmaE, UmaI;
    public Button btn1, btn2, btn3, btn4 , ret;
    public GameObject DormitoryP, DormitoryRoomP;
    public GameObject RoomObject;
    public GameObject Uma;
    public Animator UmaA;
    public GameObject kitasan, diamond, cafe, mcqueen, goldship, oguri;
    public GameObject DormitoryCamera, RoomCamera;
    static public bool ChooseUma = false;



    // Start is called before the first frame update
    void Start()
    {
        DormitoryP = GameObject.Find("Dormitory");
        DormitoryRoomP = GameObject.Find("DormitoryRoom");
        RoomObject = GameObject.Find("RoomObject");
        UmaT = GameObject.Find("UmaT");
        UmaP = GameObject.Find("UmaP");
        UmaS = GameObject.Find("UmaS");
        UmaE = GameObject.Find("UmaE");
        UmaI = GameObject.Find("UmaI");
        btn1 = GameObject.Find("btn1").GetComponent<Button>();
        btn2 = GameObject.Find("btn2").GetComponent<Button>();
        btn3 = GameObject.Find("btn3").GetComponent<Button>();
        btn4 = GameObject.Find("btn4").GetComponent<Button>();
        ret = GameObject.Find("Return").GetComponent<Button>();
        DormitoryCamera = GameObject.Find("DormitoryCamera");
        RoomCamera = GameObject.Find("RoomCamera");
        RoomCamera.SetActive(false);
        btn1.onClick.AddListener(btn1click);
        btn2.onClick.AddListener(btn2click);
        btn3.onClick.AddListener(btn3click);
        btn4.onClick.AddListener(btn4click);
        ret.onClick.AddListener(Return);
        DormitoryRoomP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UmaS.GetComponent<Text>().text = "" + Speed;
        UmaI.GetComponent<Text>().text = "" + Int;
        UmaE.GetComponent<Text>().text = "" + Energy;
        UmaP.GetComponent<Text>().text = "" + Power;
        if (type == 0) UmaT.GetComponent<Image>().sprite = null;
        if (type == 1) UmaT.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (type == 2) UmaT.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (type == 3) UmaT.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (type == 4) UmaT.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (type == 5) UmaT.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (type == 6) UmaT.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");
        if (ChooseUma)
        {
            DormitoryCamera.SetActive(false);
            RoomCamera.SetActive(true);
            switch (type)
            {
                case 1:
                    Uma = Instantiate(kitasan, RoomObject.transform.position, Quaternion.Euler(0, 100, 0));
                    UmaA = Uma.GetComponent<Animator>();
                    ChooseUma = false;
                    break;
                case 2:
                    Uma = Instantiate(diamond, RoomObject.transform.position, Quaternion.Euler(0, 100, 0));
                    UmaA = Uma.GetComponent<Animator>();
                    ChooseUma = false;
                    break;              
                case 3:
                    Uma = Instantiate(cafe, RoomObject.transform.position, Quaternion.Euler(0, 100, 0));
                    UmaA = Uma.GetComponent<Animator>();
                    ChooseUma = false;
                    break;
                case 4:
                    Uma = Instantiate(mcqueen, RoomObject.transform.position, Quaternion.Euler(0, 100, 0));
                    UmaA = Uma.GetComponent<Animator>();
                    ChooseUma = false;
                    break;
                case 5:
                    Uma = Instantiate(goldship, RoomObject.transform.position, Quaternion.Euler(0, 100, 0));
                    UmaA = Uma.GetComponent<Animator>();
                    ChooseUma = false;
                    break;
                case 6:
                    Uma = Instantiate(oguri, RoomObject.transform.position, Quaternion.Euler(0, 100, 0));
                    UmaA = Uma.GetComponent<Animator>();
                    ChooseUma = false;
                    break;
            }
        }
    }

    void btn1click() {
        UmaA.Play("jump");
    }
    void btn2click() {
        UmaA.Play("reflesh");
    }
    void btn3click()
    {
        UmaA.Play("lose");
    }
    void btn4click()
    {
        UmaA.Play("damage");
    }
    void Return()
    {
        Destroy(Uma);
        DormitoryP.SetActive(true);
        DormitoryRoomP.SetActive(false);
        DormitoryCamera.SetActive(true);
        RoomCamera.SetActive(false);
    }
}
