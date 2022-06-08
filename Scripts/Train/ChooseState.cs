using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseState : MonoBehaviour
{
    // Start is called before the first frame update
    Button btn1, btn2, btn3, btn4, btn5, btn6, ret;
    public AudioSource TrainBGM;
    static public GameObject Camera;
    void Start()
    {
        btn1 = GameObject.Find("Button1").GetComponent<Button>();
        btn2 = GameObject.Find("Button2").GetComponent<Button>();
        btn3 = GameObject.Find("Button3").GetComponent<Button>();
        btn4 = GameObject.Find("Button4").GetComponent<Button>();
        btn5 = GameObject.Find("Button5").GetComponent<Button>();
        btn6 = GameObject.Find("Button6").GetComponent<Button>();
        ret = GameObject.Find("Return").GetComponent<Button>();
        TrainBGM = GameObject.Find("Home").GetComponent<AudioSource>();
        Camera = GameObject.Find("Camera");
        btn1.onClick.AddListener(btn1click);
        btn2.onClick.AddListener(btn2click);
        btn3.onClick.AddListener(btn3click);
        btn4.onClick.AddListener(btn4click);
        btn5.onClick.AddListener(btn5click);
        btn6.onClick.AddListener(btn6click);
        ret.onClick.AddListener(retclick);
        TrainBGM.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btn1click()
    {
        TrainBGM.enabled = true;
        Camera.SetActive(false);
        TrainScene.ChooseUma = 1;
        TrainScene.StateNum = 2;
    }
    void btn2click()
    {
        TrainBGM.enabled = true;
        Camera.SetActive(false);
        TrainScene.ChooseUma = 2;
        TrainScene.StateNum = 2;
    }
    void btn3click()
    {
        TrainBGM.enabled = true;
        Camera.SetActive(false);
        TrainScene.ChooseUma = 3;
        TrainScene.StateNum = 2;
    }
    void btn4click()
    {
        TrainBGM.enabled = true;
        Camera.SetActive(false);
        TrainScene.ChooseUma = 4;
        TrainScene.StateNum = 2;
    }
    void btn5click()
    {
        TrainBGM.enabled = true;
        Camera.SetActive(false);
        TrainScene.ChooseUma = 5;
        TrainScene.StateNum = 2;
    }
    void btn6click()
    {
        TrainBGM.enabled = true;
        Camera.SetActive(false);
        TrainScene.ChooseUma = 6;
        TrainScene.StateNum = 2;
    }
    void retclick()
    {
        TrainScene.StateNum = 0;
        TrainLoading.loadingImage.SetActive(true);
        StartCoroutine(TrainLoading.LoadLevelWithBar("Main", TrainLoading.loadingBar));
    }

}
