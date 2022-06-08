using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceChoose : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Return, PC1,PC2, PC3, PVP;
    static public GameObject ChooseRace, ChooseUma, RaceUma;
    static public int mode,Uma = 0;
    static public bool ChooseFinished = false;
    void Start()
    {
        Return = GameObject.Find("Return").GetComponent<Button>();
        PC1 = GameObject.Find("PC1").GetComponent<Button>();
        PC2 = GameObject.Find("PC2").GetComponent<Button>();
        PC3 = GameObject.Find("PC3").GetComponent<Button>();
        PVP = GameObject.Find("PVP").GetComponent<Button>();
        ChooseUma = GameObject.Find("ChooseUma");
        ChooseRace = GameObject.Find("RaceChoose");
        RaceUma = GameObject.Find("Race");
        Return.onClick.AddListener(returnclick);
        PC1.onClick.AddListener(pc1click);
        PC2.onClick.AddListener(pc2click);
        PC3.onClick.AddListener(pc3click);
        PVP.onClick.AddListener(pvpclick);
        ChooseUma.SetActive(false);
        RaceUma.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseFinished)
        {
            ChooseFinished = false;
            ChooseUma.SetActive(false);
            ChooseRace.SetActive(false);          
            Race.PlayerUma = Uma;
            Race.mode = mode;
            RaceChoose.RaceUma.SetActive(true);
            Race.RaceStart = true;
        }
    }

    void returnclick()
    {
        RaceLoading.loadingImage.SetActive(true);
        StartCoroutine(RaceLoading.LoadLevelWithBar("Main", RaceLoading.loadingBar));
        mode = 0;
        ChooseUma.SetActive(false);
    }
    void pc1click()
    {
        ChooseUma.SetActive(true);
        mode = 1;
    }
    void pc2click()
    {
        ChooseUma.SetActive(true);
        mode = 2;
    }
    void pc3click()
    {
        ChooseUma.SetActive(true);
        mode = 3;
    }
    void pvpclick()
    {
        ChooseUma.SetActive(true);
        mode = 4;
    }

}
