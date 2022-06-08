using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ChooseRaceUma : MonoBehaviour
{
    // Start is called before the first frame update
    string LoadData;
    public Umafile[] Uma;
    public Data[] UmaData = new Data[4];
    public Button Uma1B, Uma2B, Uma3B, Uma4B;
    public GameObject Uma1T, Uma2T, Uma3T, Uma4T;
    public GameObject Uma1S, Uma2S, Uma3S, Uma4S;
    public GameObject Uma1P, Uma2P, Uma3P, Uma4P;
    public GameObject Uma1E, Uma2E, Uma3E, Uma4E;
    public GameObject Uma1I, Uma2I, Uma3I, Uma4I;
    string path = Application.streamingAssetsPath + "/Umafile";
    void Start()
    {
        Uma1B = GameObject.Find("Uma1B").GetComponent<Button>();
        Uma2B = GameObject.Find("Uma2B").GetComponent<Button>();
        Uma3B = GameObject.Find("Uma3B").GetComponent<Button>();
        Uma4B = GameObject.Find("Uma4B").GetComponent<Button>();
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
        Uma1B.onClick.AddListener(Uma1Bclick);
        Uma2B.onClick.AddListener(Uma2Bclick);
        Uma3B.onClick.AddListener(Uma3Bclick);
        Uma4B.onClick.AddListener(Uma4Bclick);
    }

    // Update is called once per frame
    void Update()
    {
        refresh();
    }

    void Uma1Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[0].type != 0)
        {
            RaceChoose.Uma = 1;
            RaceChoose.ChooseFinished = true;
        }
    }
    void Uma2Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[1].type != 0)
        {
            RaceChoose.Uma = 2;
            RaceChoose.ChooseFinished = true;
        }
    }
    void Uma3Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[2].type != 0)
        {
            RaceChoose.Uma = 3;
            RaceChoose.ChooseFinished = true;
        }
    }
    void Uma4Bclick()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        if (Uma[3].type != 0)
        {
            RaceChoose.Uma = 4;
            RaceChoose.ChooseFinished = true;
        }
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
