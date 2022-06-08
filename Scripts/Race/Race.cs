using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Race : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    string LoadData;
    public Umafile[] Uma;
    public int[] PVPUma = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Uma1 = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Uma2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Uma3 = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Uma4 = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public Data[] UmaData = new Data[4];
    public Button StartRace;
    public GameObject Uma1T, Uma2T, Uma3T, Uma4T;
    public GameObject Uma1S, Uma2S, Uma3S, Uma4S;
    public GameObject Uma1P, Uma2P, Uma3P, Uma4P;
    public GameObject Uma1E, Uma2E, Uma3E, Uma4E;
    public GameObject Uma1I, Uma2I, Uma3I, Uma4I;
    public GameObject UmaList, RaceUI;
    public GameObject RaceUma1, RaceUma2, RaceUma3, RaceUma4;
    public GameObject RaceUma1L, RaceUma2L, RaceUma3L, RaceUma4L;
    public GameObject kitasan, diamond, cafe, mcqueen, goldship, oguri;
    public GameObject P1, P2, P3, P4;
    static public bool RaceStart = false, Racing = false;
    static public int mode, PlayerUma;
    public double start = 743.57;
    public double all = 506.43;
    public int rank;
    public bool RacingFinished = false;
    public bool IsConnected = false;
    public bool ConnectingSuccess = false;
    public bool ConnectingFailed = false;
    public int ConnectingCount = 30;
    string path = Application.streamingAssetsPath + "/Umafile";
    void Start()
    {
        P1 = GameObject.Find("P1");
        P2 = GameObject.Find("P2");
        P3 = GameObject.Find("P3");
        P4 = GameObject.Find("P4");
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
        UmaList = GameObject.Find("UmaList");
        RaceUI = GameObject.Find("RaceUI");
        RaceUma1L = GameObject.Find("RaceUma1L");
        RaceUma2L = GameObject.Find("RaceUma2L");
        RaceUma3L = GameObject.Find("RaceUma3L");
        RaceUma4L = GameObject.Find("RaceUma4L");
        StartRace = GameObject.Find("StartRace").GetComponent<Button>();
        StartRace.onClick.AddListener(StartRaceclick);
        RaceUI.SetActive(false);
        UmaList.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (RaceStart)
        {
            RaceStart = false;
            StartCoroutine(UmaPrepare());
        }
        if (Racing)
        {
            P1.transform.localPosition = new Vector3((float)(-500 + ((RaceUma1.transform.position.z - start) * 1000 / all)), P1.transform.localPosition.y, P1.transform.localPosition.z);
            P2.transform.localPosition = new Vector3((float)(-500 + ((RaceUma2.transform.position.z - start) * 1000 / all)), P2.transform.localPosition.y, P2.transform.localPosition.z);
            P3.transform.localPosition = new Vector3((float)(-500 + ((RaceUma3.transform.position.z - start) * 1000 / all)), P3.transform.localPosition.y, P3.transform.localPosition.z);
            P4.transform.localPosition = new Vector3((float)(-500 + ((RaceUma4.transform.position.z - start) * 1000 / all)), P4.transform.localPosition.y, P4.transform.localPosition.z);
            if (Uma1[1] > 200) RaceUma1.GetComponent<Animator>().SetBool("speedup", true);
            else RaceUma1.GetComponent<Animator>().SetBool("speedup", false);
            if (Uma2[1] > 200) RaceUma2.GetComponent<Animator>().SetBool("speedup", true);
            else RaceUma2.GetComponent<Animator>().SetBool("speedup", false);
            if (Uma3[1] > 200) RaceUma3.GetComponent<Animator>().SetBool("speedup", true);
            else RaceUma3.GetComponent<Animator>().SetBool("speedup", false);
            if (Uma4[1] > 200) RaceUma4.GetComponent<Animator>().SetBool("speedup", true);
            else RaceUma4.GetComponent<Animator>().SetBool("speedup", false);
            if (Uma1[1] < 150) RaceUma1.GetComponent<Animator>().SetBool("speeddown", true);
            else RaceUma1.GetComponent<Animator>().SetBool("speeddown", false);
            if (Uma2[1] < 150) RaceUma1.GetComponent<Animator>().SetBool("speeddown", true);
            else RaceUma2.GetComponent<Animator>().SetBool("speeddown", false);
            if (Uma3[1] < 150) RaceUma1.GetComponent<Animator>().SetBool("speeddown", true);
            else RaceUma3.GetComponent<Animator>().SetBool("speeddown", false);
            if (Uma4[1] < 150) RaceUma1.GetComponent<Animator>().SetBool("speeddown", true);
            else RaceUma4.GetComponent<Animator>().SetBool("speeddown", false);
        }
        if (RacingFinished)
        {
            RaceUma1.GetComponent<Animator>().Play("idle");
            RaceUma2.GetComponent<Animator>().Play("idle");
            RaceUma3.GetComponent<Animator>().Play("idle");
            RaceUma4.GetComponent<Animator>().Play("idle");
            Uma1[6] = 0;
            Uma1[7] = 0;
            Uma2[6] = 0;
            Uma2[7] = 0;
            Uma3[6] = 0;
            Uma3[7] = 0;
            Uma4[6] = 0;
            Uma4[7] = 0;
            Racing = false;
            RaceChat.C.GetComponent<Text>().text = "你得到第" + rank + "名";
            RaceChat.RC.SetActive(true);
            if (RaceChat.ReturnB)
            {
                RaceChat.ReturnB = false;
                RacingFinished = false;
                EndRace();
            }
        }
        if (IsConnected && !ConnectingFailed)
        {          
            RaceChat.RC.SetActive(true);
            RaceChat.RoomC.SetActive(true);
            RaceChat.RoomC.GetComponent<Text>().text = RaceChat.RoomC.GetComponent<Text>().text = "(配對人數：" + PhotonNetwork.CurrentRoom.PlayerCount + " / 4)";
            if (PhotonNetwork.CurrentRoom.PlayerCount == 4 && !ConnectingSuccess)
            {
                ConnectingCount = 30;
                CancelInvoke();
                Debug.Log("配對成功");
                RaceChat.C.GetComponent<Text>().text = "配對成功";
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("ChangeData", RpcTarget.Others, PVPUma);
                ConnectingSuccess = true;
            }
        }
        if (ConnectingSuccess)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RaceChat.RoomC.SetActive(false);
                PhotonNetwork.Disconnect();
                ConnectingSuccess = false;
                IsConnected = false;
            }
        }
        if (ConnectingFailed)
        {
            RaceChat.C.GetComponent<Text>().text = "配對失敗";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RaceChat.RoomC.SetActive(false);
                ConnectingFailed = false;
                IsConnected = false;
            }
        }
    }

    void StartRaceclick()
    {
        Racing = true;
        RaceUma1.GetComponentInChildren<Camera>().enabled = true;
        RaceUma1.GetComponentInChildren<Camera>().transform.localPosition = new Vector3((float)-1.823, (float)2.1826, (float)2.796);
        RaceUma1.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.Euler(20, 150, 0);
        UmaList.SetActive(false);
        RaceUI.SetActive(true);
        InvokeRepeating("RaceCalculator", 0.2f, 0.2f);
        RaceUma1.GetComponent<Animator>().Play("run");
        RaceUma2.GetComponent<Animator>().Play("run");
        RaceUma3.GetComponent<Animator>().Play("run");
        RaceUma4.GetComponent<Animator>().Play("run");
    }

    void EnemyCreate(int[] Uma, int mode)
    {
        Uma[0] = Random.Range(1, 7);
        switch (mode)
        {
            case 1:
                Uma[1] = 100;
                Uma[2] = 75;
                Uma[3] = 75;
                Uma[4] = 50;
                Uma[6] = 0;
                Uma[7] = 0;
                break;
            case 2:
                Uma[1] = 125;
                Uma[2] = 100;
                Uma[3] = 75;
                Uma[4] = 50;
                Uma[6] = 0;
                Uma[7] = 0;
                break;
            case 3:
                Uma[1] = 150;
                Uma[2] = 100;
                Uma[3] = 100;
                Uma[4] = 75;
                Uma[6] = 0;
                Uma[7] = 0;
                break;
            case 4:
                PVPUma = Uma1;
                for (int i = 0; i < 8; i++)
                {
                    Uma2[i] = 0;
                    Uma3[i] = 0;
                    Uma4[i] = 0;
                }
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.JoinRandomRoom();
                IsConnected = true;
                RaceChat.RC.SetActive(true);
                RaceChat.C.GetComponent<Text>().text = "配對中...\n" + ConnectingCount;
                InvokeRepeating("Connecting", 1, 1);
                break;
        }
        if (mode != 4)
        {
            for (int i = 0; i < 300; i++)
            {
                int r = Random.Range(1, 5);
                switch (r)
                {
                    case 1:
                        Uma[1] += 1;
                        break;
                    case 2:
                        Uma[2] += 1;
                        break;
                    case 3:
                        Uma[3] += 1;
                        break;
                    case 4:
                        Uma[4] += 1;
                        break;
                }
            }
        }
    }

    IEnumerator UmaPrepare()
    {
        LoadData = File.ReadAllText(path);
        Uma = JsonHelper.FromJson<Umafile>(LoadData);
        Uma1[0] = Uma[PlayerUma - 1].type;
        Uma1[1] = Uma[PlayerUma - 1].Speed;
        Uma1[2] = Uma[PlayerUma - 1].Energy;
        Uma1[3] = Uma[PlayerUma - 1].Power;
        Uma1[4] = Uma[PlayerUma - 1].Int;

        if (mode != 4)
        {
            EnemyCreate(Uma2, mode);
            EnemyCreate(Uma3, mode);
            EnemyCreate(Uma4, mode);
        }
        else EnemyCreate(Uma2, mode);

        yield return new WaitUntil(() => !IsConnected);

        if (Uma1[0] == 0) Uma1T.GetComponent<Image>().sprite = null;
        if (Uma1[0] == 1) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma1[0] == 2) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma1[0] == 3) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma1[0] == 4) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma1[0] == 5) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma1[0] == 6) Uma1T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        if (Uma2[0] == 0) Uma2T.GetComponent<Image>().sprite = null;
        if (Uma2[0] == 1) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma2[0] == 2) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma2[0] == 3) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma2[0] == 4) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma2[0] == 5) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma2[0] == 6) Uma2T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        if (Uma3[0] == 0) Uma3T.GetComponent<Image>().sprite = null;
        if (Uma3[0] == 1) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma3[0] == 2) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma3[0] == 3) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma3[0] == 4) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma3[0] == 5) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma3[0] == 6) Uma3T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        if (Uma4[0] == 0) Uma4T.GetComponent<Image>().sprite = null;
        if (Uma4[0] == 1) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/kitasan");
        if (Uma4[0] == 2) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/diamond");
        if (Uma4[0] == 3) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/cafe");
        if (Uma4[0] == 4) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/mcqueen");
        if (Uma4[0] == 5) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/goldship");
        if (Uma4[0] == 6) Uma4T.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("Pictures/oguri");

        Uma1S.GetComponent<Text>().text = "" + Uma1[1];
        Uma1P.GetComponent<Text>().text = "" + Uma1[3];
        Uma1E.GetComponent<Text>().text = "" + Uma1[2];
        Uma1I.GetComponent<Text>().text = "" + Uma1[4];
        Uma2S.GetComponent<Text>().text = "" + Uma2[1];
        Uma2P.GetComponent<Text>().text = "" + Uma2[3];
        Uma2E.GetComponent<Text>().text = "" + Uma2[2];
        Uma2I.GetComponent<Text>().text = "" + Uma2[4];
        Uma3S.GetComponent<Text>().text = "" + Uma3[1];
        Uma3P.GetComponent<Text>().text = "" + Uma3[3];
        Uma3E.GetComponent<Text>().text = "" + Uma3[2];
        Uma3I.GetComponent<Text>().text = "" + Uma3[4];
        Uma4S.GetComponent<Text>().text = "" + Uma4[1];
        Uma4P.GetComponent<Text>().text = "" + Uma4[3];
        Uma4E.GetComponent<Text>().text = "" + Uma4[2];
        Uma4I.GetComponent<Text>().text = "" + Uma4[4];

        switch (Uma1[0])
        {
            case 1:
                RaceUma1 = Instantiate(kitasan, RaceUma1L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                RaceUma1 = Instantiate(diamond, RaceUma1L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 3:
                RaceUma1 = Instantiate(cafe, RaceUma1L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 4:
                RaceUma1 = Instantiate(mcqueen, RaceUma1L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 5:
                RaceUma1 = Instantiate(goldship, RaceUma1L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 6:
                RaceUma1 = Instantiate(oguri, RaceUma1L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
        }
        switch (Uma2[0])
        {
            case 1:
                RaceUma2 = Instantiate(kitasan, RaceUma2L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                RaceUma2 = Instantiate(diamond, RaceUma2L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 3:
                RaceUma2 = Instantiate(cafe, RaceUma2L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 4:
                RaceUma2 = Instantiate(mcqueen, RaceUma2L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 5:
                RaceUma2 = Instantiate(goldship, RaceUma2L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 6:
                RaceUma2 = Instantiate(oguri, RaceUma2L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
        }
        switch (Uma3[0])
        {
            case 1:
                RaceUma3 = Instantiate(kitasan, RaceUma3L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                RaceUma3 = Instantiate(diamond, RaceUma3L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 3:
                RaceUma3 = Instantiate(cafe, RaceUma3L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 4:
                RaceUma3 = Instantiate(mcqueen, RaceUma3L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 5:
                RaceUma3 = Instantiate(goldship, RaceUma3L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 6:
                RaceUma3 = Instantiate(oguri, RaceUma3L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
        }
        switch (Uma4[0])
        {
            case 1:
                RaceUma4 = Instantiate(kitasan, RaceUma4L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                RaceUma4 = Instantiate(diamond, RaceUma4L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 3:
                RaceUma4 = Instantiate(cafe, RaceUma4L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 4:
                RaceUma4 = Instantiate(mcqueen, RaceUma4L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 5:
                RaceUma4 = Instantiate(goldship, RaceUma4L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            case 6:
                RaceUma4 = Instantiate(oguri, RaceUma4L.transform.position, new Quaternion(0, 0, 0, 0));
                break;
        }
        RaceUma1.GetComponentInChildren<Camera>().enabled = false;
        RaceUma2.GetComponentInChildren<Camera>().enabled = false;
        RaceUma3.GetComponentInChildren<Camera>().enabled = false;
        RaceUma4.GetComponentInChildren<Camera>().enabled = false;
        UmaList.SetActive(true);
    }

    void RaceCalculator()
    {
        if (Uma1[6] > 0) Uma1[6] -= 1;
        if (Uma2[6] > 0) Uma2[6] -= 1;
        if (Uma3[6] > 0) Uma3[6] -= 1;
        if (Uma4[6] > 0) Uma4[6] -= 1;
        if (Uma1[7] > 0) Uma1[7] -= 1;
        if (Uma2[7] > 0) Uma2[7] -= 1;
        if (Uma3[7] > 0) Uma3[7] -= 1;
        if (Uma4[7] > 0) Uma4[7] -= 1;
        if (RaceUma1.transform.position.z > 1250 || RaceUma2.transform.position.z > 1250 || RaceUma3.transform.position.z > 1250 || RaceUma4.transform.position.z > 1250)
        {
            CancelInvoke();
            Ranking();
            Racing = false;
            RacingFinished = true;
            RaceChat.ReturnB = false;
        }
        CalculateSpeed(Uma1);
        CalculateSpeed(Uma2);
        CalculateSpeed(Uma3);
        CalculateSpeed(Uma4);
        RaceUma1.transform.position += new Vector3(0, 0, Uma1[1] / 20);
        RaceUma2.transform.position += new Vector3(0, 0, Uma2[1] / 20);
        RaceUma3.transform.position += new Vector3(0, 0, Uma3[1] / 20);
        RaceUma4.transform.position += new Vector3(0, 0, Uma4[1] / 20);
    }
    void EndRace()
    {
        RaceLoading.loadingImage.SetActive(true);
        StartCoroutine(RaceLoading.LoadLevelWithBar("Main", RaceLoading.loadingBar));
        Destroy(RaceUma1);
        Destroy(RaceUma2);
        Destroy(RaceUma3);
        Destroy(RaceUma4);
        P1.transform.localPosition = new Vector3(-500, P2.transform.localPosition.y, P1.transform.localPosition.z);
        P2.transform.localPosition = new Vector3(-500, P2.transform.localPosition.y, P2.transform.localPosition.z);
        P3.transform.localPosition = new Vector3(-500, P3.transform.localPosition.y, P3.transform.localPosition.z);
        P4.transform.localPosition = new Vector3(-500, P4.transform.localPosition.y, P4.transform.localPosition.z);
        UmaList.SetActive(true);
        RaceUI.SetActive(true);
        RaceChoose.ChooseUma.SetActive(true);
        RaceChoose.RaceUma.SetActive(true);
    }

    void Ranking()
    {
        if (RaceUma1.transform.position.z > RaceUma2.transform.position.z && RaceUma1.transform.position.z > RaceUma3.transform.position.z && RaceUma1.transform.position.z > RaceUma4.transform.position.z)
        {
            rank = 1;
        }
        else if ((RaceUma1.transform.position.z > RaceUma2.transform.position.z && RaceUma1.transform.position.z > RaceUma3.transform.position.z) || (RaceUma1.transform.position.z > RaceUma2.transform.position.z && RaceUma1.transform.position.z > RaceUma4.transform.position.z) || (RaceUma1.transform.position.z > RaceUma3.transform.position.z && RaceUma1.transform.position.z > RaceUma4.transform.position.z))
        {
            rank = 2;
        }
        else if (RaceUma1.transform.position.z > RaceUma2.transform.position.z || RaceUma1.transform.position.z > RaceUma3.transform.position.z || RaceUma1.transform.position.z > RaceUma4.transform.position.z)
        {
            rank = 3;
        }
        else rank = 4;
    }

    void CalculateSpeed(int[] Uma)
    {
        if (Uma[2] > 0)
        {
            if (Uma[4] >= 180)
            {
                int r = Random.Range(0, 2);
                switch (r)
                {
                    case 0:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 1:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                }
            }
            if (Uma[4] >= 140 && Uma[4] < 180)
            {
                int r = Random.Range(0, 10);
                switch (r)
                {
                    case 0:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 1:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 2:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 3:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 4:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 5:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 6:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 7:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 8:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 9:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                }
            }
            if (Uma[4] <= 140)
            {
                int r = Random.Range(0, 10);
                switch (r)
                {
                    case 0:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 1:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 2:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 3:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 4:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 5:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 6:
                        if (Uma[6] == 0)
                        {
                            Uma[6] = 5;
                            Uma[1] += Uma[3] / 10;
                        }
                        break;
                    case 7:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 8:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                    case 9:
                        if (Uma[6] == 0) Uma[6] += 2;
                        break;
                }
            }
            Uma[2] -= Uma[1] / 15;
        }
        else
        {
            if (Uma[4] >= 180)
            {
                int r = Random.Range(0, 2);
                switch (r)
                {
                    case 0:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 1:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                }
            }
            if (Uma[4] >= 140 && Uma[4] < 180)
            {
                int r = Random.Range(0, 10);
                switch (r)
                {
                    case 0:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 1:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                    case 2:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 3:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                    case 4:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 5:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                    case 6:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 7:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                    case 8:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 9:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                }
            }
            if (Uma[4] < 140)
            {
                int r = Random.Range(0, 10);
                switch (r)
                {
                    case 0:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 1:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                    case 2:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 3:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 4:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 5:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 6:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 7:
                        if (Uma[7] == 0)
                        {
                            Uma[7] = 7;
                            Uma[1] -= Uma[3] / 10;
                        }
                        break;
                    case 8:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                    case 9:
                        if (Uma[7] == 0) Uma[7] += 2;
                        break;
                }
            }
        }
    }

    void Connecting()
    {
        RaceChat.C.GetComponent<Text>().text = "配對中...\n" + ConnectingCount;
        if (ConnectingCount >= 1)
        {
            ConnectingCount -= 1;
        }
        else
        {
            ConnectingFailed = true;
            ConnectingCount = 30;
            CancelInvoke();
            EnemyCreate(Uma2, 3);
            EnemyCreate(Uma3, 3);
            EnemyCreate(Uma4, 3);
            PhotonNetwork.Disconnect();
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

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN 呼叫 OnConnectedToMaster(), 已連上 Photon Cloud.");
        // 確認已連上 Photon Cloud
        // 隨機加入一個遊戲室
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN 呼叫 OnDisconnected() {0}.", cause);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN 呼叫 OnJoinRandomFailed(), 隨機加入遊戲室失敗.建立遊戲室");

        // 隨機加入遊戲室失敗. 可能原因是 1. 沒有遊戲室 或 2. 有的都滿了.    
        // 好吧, 我們自己開一個遊戲室.
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("PUN 呼叫 OnJoinedRoom(), 已成功進入遊戲室中.");
    }

    [PunRPC]
    void ChangeData(int[] PVPUma)
    {
        if (Uma2[0] == 0) Uma2 = PVPUma;
        else if (Uma3[0] == 0) Uma3 = PVPUma;
        else Uma4 = PVPUma;
    }

}
