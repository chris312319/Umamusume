using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dormitory : MonoBehaviour
{

    [System.Serializable]
    public class Umafile
    {
        public int type;
        public int AltiLevel;
        public int Speed;
        public int Energy;
        public int Power;
        public int Int;
        public int UmaCount;
    }

    string LoadData;
    public Umafile[] Uma;
    public Data[] UmaData = new Data[4];  
    //string testJsonPath = Application.streamingAssetsPath + "/Umafile";
    //string testJsonPath = "D:/download/Umamusume Pretty Derby/Umamusume Pretty Derby/Assets/Umafile";  
    public Button Uma1B, Uma2B, Uma3B, Uma4B, Refresh, Back;
    public Button Uma1D, Uma2D, Uma3D, Uma4D;
    public GameObject Uma1T, Uma2T, Uma3T, Uma4T;
    public GameObject Uma1S, Uma2S, Uma3S, Uma4S;
    public GameObject Uma1P, Uma2P, Uma3P, Uma4P;
    public GameObject Uma1E, Uma2E, Uma3E, Uma4E;
    public GameObject Uma1I, Uma2I, Uma3I, Uma4I;
    // Start is called before the first frame update
    public GameObject Uma1, Uma2, Uma3, Uma4;
    public GameObject DormitoryP, DormitoryRoomP;
    public GameObject kitasan, diamond, oguri;
    public GameObject DormitoryCamera, RoomCamera;
    string path = Application.streamingAssetsPath + "/Umafile";
    void Start()
    {
        DormitoryP = GameObject.Find("Dormitory");
        DormitoryRoomP = GameObject.Find("DormitoryRoom");


        Uma1B = GameObject.Find("Uma1B").GetComponent<Button>(); 
        Uma2B = GameObject.Find("Uma2B").GetComponent<Button>(); 
        Uma3B = GameObject.Find("Uma3B").GetComponent<Button>(); 
        Uma4B = GameObject.Find("Uma4B").GetComponent<Button>(); 
        Refresh = GameObject.Find("Refresh").GetComponent<Button>(); 
        Back = GameObject.Find("Back").GetComponent<Button>(); 
        Uma1T = GameObject.Find("Uma1T");
        Uma2T = GameObject.Find("Uma2T");
        Uma3T = GameObject.Find("Uma3T");
        Uma4T = GameObject.Find("Uma4T");
        Uma1S = GameObject.Find("Uma1S");
        Uma2S = GameObject.Find("Uma2S");
        Uma3S = GameObject.Find("Uma3S");
        Uma4S = GameObject.Find("Uma4S");
        Uma1P = GameObject.Find("Uma1P");
        Uma2P = GameObject.Find("Uma2P");
        Uma3P = GameObject.Find("Uma3P");
        Uma4P = GameObject.Find("Uma4P");
        Uma1E = GameObject.Find("Uma1E");
        Uma2E = GameObject.Find("Uma2E");
        Uma3E = GameObject.Find("Uma3E");
        Uma4E = GameObject.Find("Uma4E");
        Uma1I = GameObject.Find("Uma1I");
        Uma2I = GameObject.Find("Uma2I");
        Uma3I = GameObject.Find("Uma3I");
        Uma4I = GameObject.Find("Uma4I");
        Uma1D = GameObject.Find("Uma1D").GetComponent<Button>();
        Uma2D = GameObject.Find("Uma2D").GetComponent<Button>();
        Uma3D = GameObject.Find("Uma3D").GetComponent<Button>();
        Uma4D = GameObject.Find("Uma4D").GetComponent<Button>();
        Uma1B.onClick.AddListener(Uma1Bclick);
        Uma2B.onClick.AddListener(Uma2Bclick);
        Uma3B.onClick.AddListener(Uma3Bclick);
        Uma4B.onClick.AddListener(Uma4Bclick);
        Refresh.onClick.AddListener(Refreshclick);
        Back.onClick.AddListener(Backclick);
        Uma1D.onClick.AddListener(Uma1Dclick);
        Uma2D.onClick.AddListener(Uma2Dclick);
        Uma3D.onClick.AddListener(Uma3Dclick);
        Uma4D.onClick.AddListener(Uma4Dclick);
        refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Uma1Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[0].type != 0) {
            DormitoryRoom.type = Uma[0].type;
            DormitoryRoom.Speed = Uma[0].Speed;
            DormitoryRoom.Power = Uma[0].Power;
            DormitoryRoom.Int = Uma[0].Int;
            DormitoryRoom.Energy = Uma[0].Energy;
            DormitoryRoom.ChooseUma = true;
            DormitoryP.SetActive(false);
            DormitoryRoomP.SetActive(true);
        }
    }
    void Uma2Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[1].type != 0)
        {
            DormitoryRoom.type = Uma[1].type;
            DormitoryRoom.Speed = Uma[1].Speed;
            DormitoryRoom.Power = Uma[1].Power;
            DormitoryRoom.Int = Uma[1].Int;
            DormitoryRoom.Energy = Uma[1].Energy;
            DormitoryRoom.ChooseUma = true;
            DormitoryP.SetActive(false);
            DormitoryRoomP.SetActive(true);
        }

    }
    void Uma3Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[2].type != 0)
        {
            DormitoryRoom.type = Uma[2].type;
            DormitoryRoom.Speed = Uma[2].Speed;
            DormitoryRoom.Power = Uma[2].Power;
            DormitoryRoom.Int = Uma[2].Int;
            DormitoryRoom.Energy = Uma[2].Energy;
            DormitoryRoom.ChooseUma = true;
            DormitoryP.SetActive(false);
            DormitoryRoomP.SetActive(true);
        }

    }
    void Uma4Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[3].type != 0)
        {
            DormitoryRoom.type = Uma[3].type;
            DormitoryRoom.Speed = Uma[3].Speed;
            DormitoryRoom.Power = Uma[3].Power;
            DormitoryRoom.Int = Uma[3].Int;
            DormitoryRoom.Energy = Uma[3].Energy;
            DormitoryRoom.ChooseUma = true;
            DormitoryP.SetActive(false);
            DormitoryRoomP.SetActive(true);
        }
    }
    void Refreshclick()
    {
        refresh();
     }
    void Backclick()
    {
        DormitoryLoading.loadingImage.SetActive(true);
        StartCoroutine(DormitoryLoading.LoadLevelWithBar("Main", DormitoryLoading.loadingBar));
    }
    void Uma1Dclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        UmaData[0] = new Data();
        UmaData[1] = new Data();
        UmaData[2] = new Data();
        UmaData[3] = new Data();
        UmaData[0].type = Uma[1].type;
        UmaData[1].type = Uma[2].type;
        UmaData[2].type = Uma[3].type;
        UmaData[3].type = 0; 
        UmaData[0].AltiLevel = Uma[1].AltiLevel;
        UmaData[1].AltiLevel = Uma[2].AltiLevel;
        UmaData[2].AltiLevel = Uma[3].AltiLevel;
        UmaData[3].AltiLevel = 0;
        UmaData[0].Speed = Uma[1].Speed;
        UmaData[1].Speed = Uma[2].Speed;
        UmaData[2].Speed = Uma[3].Speed;
        UmaData[3].Speed = 0;
        UmaData[0].Power = Uma[1].Power;
        UmaData[1].Power = Uma[2].Power;
        UmaData[2].Power = Uma[3].Power;
        UmaData[3].Power = 0;
        UmaData[0].Energy = Uma[1].Energy;
        UmaData[1].Energy = Uma[2].Energy;
        UmaData[2].Energy = Uma[3].Energy;
        UmaData[3].Energy = 0;
        UmaData[0].Int = Uma[1].Int;
        UmaData[1].Int = Uma[2].Int;
        UmaData[2].Int = Uma[3].Int;
        UmaData[3].Int = 0;
        UmaData[0].UmaCount = Uma[1].UmaCount;
        UmaData[1].UmaCount = Uma[2].UmaCount;
        UmaData[2].UmaCount = Uma[3].UmaCount;
        UmaData[3].UmaCount = 0;
        string jsonInfo = JsonHelper.ToJson(UmaData, true);
        File.WriteAllText(path, jsonInfo);
        refresh();
    }
    void Uma2Dclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        UmaData[0] = new Data();
        UmaData[1] = new Data();
        UmaData[2] = new Data();
        UmaData[3] = new Data();
        UmaData[0].type = Uma[0].type;
        UmaData[1].type = Uma[2].type;
        UmaData[2].type = Uma[3].type;
        UmaData[3].type = 0;
        UmaData[0].AltiLevel = Uma[0].AltiLevel;
        UmaData[1].AltiLevel = Uma[2].AltiLevel;
        UmaData[2].AltiLevel = Uma[3].AltiLevel;
        UmaData[3].AltiLevel = 0;
        UmaData[0].Speed = Uma[0].Speed;
        UmaData[1].Speed = Uma[2].Speed;
        UmaData[2].Speed = Uma[3].Speed;
        UmaData[3].Speed = 0;
        UmaData[0].Power = Uma[0].Power;
        UmaData[1].Power = Uma[2].Power;
        UmaData[2].Power = Uma[3].Power;
        UmaData[3].Power = 0;
        UmaData[0].Energy = Uma[0].Energy;
        UmaData[1].Energy = Uma[2].Energy;
        UmaData[2].Energy = Uma[3].Energy;
        UmaData[3].Energy = 0;
        UmaData[0].Int = Uma[0].Int;
        UmaData[1].Int = Uma[2].Int;
        UmaData[2].Int = Uma[3].Int;
        UmaData[3].Int = 0;
        UmaData[0].UmaCount = Uma[0].UmaCount;
        UmaData[1].UmaCount = Uma[2].UmaCount;
        UmaData[2].UmaCount = Uma[3].UmaCount;
        UmaData[3].UmaCount = 0;
        string jsonInfo = JsonHelper.ToJson(UmaData, true);
        File.WriteAllText(path, jsonInfo);
        refresh();

    }
    void Uma3Dclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        UmaData[0] = new Data();
        UmaData[1] = new Data();
        UmaData[2] = new Data();
        UmaData[3] = new Data();
        UmaData[0].type = Uma[0].type;
        UmaData[1].type = Uma[1].type;
        UmaData[2].type = Uma[3].type;
        UmaData[3].type = 0;
        UmaData[0].AltiLevel = Uma[0].AltiLevel;
        UmaData[1].AltiLevel = Uma[1].AltiLevel;
        UmaData[2].AltiLevel = Uma[3].AltiLevel;
        UmaData[3].AltiLevel = 0;
        UmaData[0].Speed = Uma[0].Speed;
        UmaData[1].Speed = Uma[1].Speed;
        UmaData[2].Speed = Uma[3].Speed;
        UmaData[3].Speed = 0;
        UmaData[0].Power = Uma[0].Power;
        UmaData[1].Power = Uma[1].Power;
        UmaData[2].Power = Uma[3].Power;
        UmaData[3].Power = 0;
        UmaData[0].Energy = Uma[0].Energy;
        UmaData[1].Energy = Uma[1].Energy;
        UmaData[2].Energy = Uma[3].Energy;
        UmaData[3].Energy = 0;
        UmaData[0].Int = Uma[0].Int;
        UmaData[1].Int = Uma[1].Int;
        UmaData[2].Int = Uma[3].Int;
        UmaData[3].Int = 0;
        UmaData[0].UmaCount = Uma[0].UmaCount;
        UmaData[1].UmaCount = Uma[1].UmaCount;
        UmaData[2].UmaCount = Uma[3].UmaCount;
        UmaData[3].UmaCount = 0;
        string jsonInfo = JsonHelper.ToJson(UmaData, true);
        File.WriteAllText(path, jsonInfo);
        refresh();
    }
    void Uma4Dclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        UmaData[0] = new Data();
        UmaData[1] = new Data();
        UmaData[2] = new Data();
        UmaData[3] = new Data();
        UmaData[0].type = Uma[0].type;
        UmaData[1].type = Uma[1].type;
        UmaData[2].type = Uma[2].type;
        UmaData[3].type = 0;
        UmaData[0].AltiLevel = Uma[0].AltiLevel;
        UmaData[1].AltiLevel = Uma[1].AltiLevel;
        UmaData[2].AltiLevel = Uma[2].AltiLevel;
        UmaData[3].AltiLevel = 0;
        UmaData[0].Speed = Uma[0].Speed;
        UmaData[1].Speed = Uma[1].Speed;
        UmaData[2].Speed = Uma[2].Speed;
        UmaData[3].Speed = 0;
        UmaData[0].Power = Uma[0].Power;
        UmaData[1].Power = Uma[1].Power;
        UmaData[2].Power = Uma[2].Power;
        UmaData[3].Power = 0;
        UmaData[0].Energy = Uma[0].Energy;
        UmaData[1].Energy = Uma[1].Energy;
        UmaData[2].Energy = Uma[2].Energy;
        UmaData[3].Energy = 0;
        UmaData[0].Int = Uma[0].Int;
        UmaData[1].Int = Uma[1].Int;
        UmaData[2].Int = Uma[2].Int;
        UmaData[3].Int = 0;
        UmaData[0].UmaCount = Uma[0].UmaCount;
        UmaData[1].UmaCount = Uma[1].UmaCount;
        UmaData[2].UmaCount = Uma[2].UmaCount;
        UmaData[3].UmaCount = 0;
        string jsonInfo = JsonHelper.ToJson(UmaData, true);
        File.WriteAllText(path, jsonInfo);
        refresh();
    }

    [System.Serializable]
    public class Data
    {
        public int type;
        public int AltiLevel;
        public int Speed;
        public int Energy;
        public int Power;
        public int Int;
        public int UmaCount;
    }
    public void refresh()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        Debug.Log("Uma Loading");
        if (Uma[0].type == 0) Uma1T.GetComponent<Image>().sprite = null;
        if (Uma[0].type == 1) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma[0].type == 2) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma[0].type == 3) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma[0].type == 4) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma[0].type == 5) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma[0].type == 6) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        if (Uma[1].type == 0) Uma2T.GetComponent<Image>().sprite = null;
        if (Uma[1].type == 1) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma[1].type == 2) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma[1].type == 3) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma[1].type == 4) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma[1].type == 5) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma[1].type == 6) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        if (Uma[2].type == 0) Uma3T.GetComponent<Image>().sprite = null;
        if (Uma[2].type == 1) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma[2].type == 2) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma[2].type == 3) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma[2].type == 4) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma[2].type == 5) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma[2].type == 6) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        if (Uma[3].type == 0) Uma4T.GetComponent<Image>().sprite = null;
        if (Uma[3].type == 1) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma[3].type == 2) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma[3].type == 3) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma[3].type == 4) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma[3].type == 5) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma[3].type == 6) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        Uma1S.GetComponent<Text>().text = "" + Uma[0].Speed;
        Uma1P.GetComponent<Text>().text = "" + Uma[0].Power;
        Uma1E.GetComponent<Text>().text = "" + Uma[0].Energy;
        Uma1I.GetComponent<Text>().text = "" + Uma[0].Int;
        Uma2S.GetComponent<Text>().text = "" + Uma[1].Speed;
        Uma2P.GetComponent<Text>().text = "" + Uma[1].Power;
        Uma2E.GetComponent<Text>().text = "" + Uma[1].Energy;
        Uma2I.GetComponent<Text>().text = "" + Uma[1].Int;
        Uma3S.GetComponent<Text>().text = "" + Uma[2].Speed;
        Uma3P.GetComponent<Text>().text = "" + Uma[2].Power;
        Uma3E.GetComponent<Text>().text = "" + Uma[2].Energy;
        Uma3I.GetComponent<Text>().text = "" + Uma[2].Int;
        Uma4S.GetComponent<Text>().text = "" + Uma[3].Speed;
        Uma4P.GetComponent<Text>().text = "" + Uma[3].Power;
        Uma4E.GetComponent<Text>().text = "" + Uma[3].Energy;
        Uma4I.GetComponent<Text>().text = "" + Uma[3].Int;
    }
}
