using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class TrainState : MonoBehaviour
{
    string LoadData;
    public Data[] Uma;
    public Data[] UmaData = new Data[4];
    static public int UmaCount = -1;
    public Button rest, speed, energy, power, inte, race, giveup;
    public int chooseNum = -1;
    public int ReadytoW = 1;
    static public int Umatype;
    public int life = 50, Intspeed = 50, Intenergy = 50, Intpower = 50, Intinte = 50, AltiLevel = 0;
    public int pspeed = 15, penergy = 15, ppower = 15, pinte = 15;
    public int round ;
    public int tspeedtime = 0, tenergytime = 0, tpowertime = 0, tinttime = 0;
    public GameObject Round, HealthBar, Speed, Energy, Power, Int;
    public GameObject PHealthBar, PSpeed, PEnergy, PPower, PInt;
    public bool preparetochoose = true;
    public GameObject kitasan, diamond, cafe, mcqueen, goldship, oguri;
    public GameObject TrainingUma,TrainingPlace;
    string path = Application.streamingAssetsPath + "/Umafile";
    public Animator UmaA;
    public GameObject classroom, gym, field , room;
    public GameObject TrainingCamera;
    // Start is called before the first frame update
    void Start()
    {
        round = 20;
        life = 100;
        pspeed = 15;
        penergy = 15;
        ppower = 15;
        pinte = 15;
        Intspeed = 50;
        Intenergy = 50;
        Intpower = 50;
        Intinte = 50;
        AltiLevel = 1;
        tspeedtime = 0;
        tenergytime = 0;
        tpowertime = 0;
        tinttime = 0;
        chooseNum = -1;
        ReadytoW = 1;
        TrainingPlace = GameObject.Find("HomeObject");
        rest = GameObject.Find("rest").GetComponent<Button>();
        speed = GameObject.Find("speed").GetComponent<Button>();
        energy = GameObject.Find("energy").GetComponent<Button>();
        power = GameObject.Find("power").GetComponent<Button>();
        inte = GameObject.Find("int").GetComponent<Button>();
        race = GameObject.Find("race").GetComponent<Button>();
        giveup = GameObject.Find("giveup").GetComponent<Button>();
        Round = GameObject.Find("Round");
        HealthBar = GameObject.Find("HealthBar");
        Speed = GameObject.Find("Speed");
        Energy = GameObject.Find("Energy");
        Power = GameObject.Find("Power");
        Int = GameObject.Find("Int");
        PSpeed = GameObject.Find("PSpeed");
        PEnergy = GameObject.Find("PEnergy");
        PPower = GameObject.Find("PPower");
        PInt = GameObject.Find("PInt");
        gym = GameObject.Find("GymObject");
        field = GameObject.Find("FieldObject");
        classroom = GameObject.Find("ClassroomObject");
        room = GameObject.Find("RoomObject");
        rest.onClick.AddListener(restclick);
        speed.onClick.AddListener(speedclick);
        energy.onClick.AddListener(energyclick);
        power.onClick.AddListener(powerclick);
        inte.onClick.AddListener(inteclick);
        race.onClick.AddListener(raceclick);
        giveup.onClick.AddListener(giveupclick);     
    }

    // Update is called once per frame
    void Update()
    {
        Speed.GetComponent<Text>().text = "" + Intspeed;
        Energy.GetComponent<Text>().text = "" + Intenergy;
        Power.GetComponent<Text>().text = "" + Intpower;
        Int.GetComponent<Text>().text = "" + Intinte;
        PSpeed.GetComponent<Text>().text = "" + pspeed;
        PEnergy.GetComponent<Text>().text = "" + penergy;
        PPower.GetComponent<Text>().text = "" + ppower;
        PInt.GetComponent<Text>().text = "" + pinte;
        HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(life*5,25);
        if (TrainScene.ChooseUma != 0 && TrainScene.StateNum == 2)
        {
            if (TrainScene.ChooseUma == 1)
            {
                TrainingUma = Instantiate(kitasan, TrainingPlace.transform.position, new Quaternion(0, 0, 0, 0));
                Umatype = 1;
                TrainScene.ChooseUma = 0;
                CameraLookAt.preparetolook = 1;
            }
            else if (TrainScene.ChooseUma == 2)
            {
                TrainingUma = Instantiate(diamond, TrainingPlace.transform.position, new Quaternion(0, 0, 0, 0));
                Umatype = 2;
                TrainScene.ChooseUma = 0;
                CameraLookAt.preparetolook = 1;
            }
            else if (TrainScene.ChooseUma == 3)
            {
                TrainingUma = Instantiate(cafe, TrainingPlace.transform.position, new Quaternion(0, 0, 0, 0));
                Umatype = 3;
                TrainScene.ChooseUma = 0;
                CameraLookAt.preparetolook = 1;
            }
            else if (TrainScene.ChooseUma == 4)
            {
                TrainingUma = Instantiate(mcqueen, TrainingPlace.transform.position, new Quaternion(0, 0, 0, 0));
                Umatype = 4;
                TrainScene.ChooseUma = 0;
                CameraLookAt.preparetolook = 1;
            }
            else if (TrainScene.ChooseUma == 5)
            {
                TrainingUma = Instantiate(goldship, TrainingPlace.transform.position, new Quaternion(0, 0, 0, 0));
                Umatype = 5;
                TrainScene.ChooseUma = 0;
                CameraLookAt.preparetolook = 1;
            }
            else if (TrainScene.ChooseUma == 6)
            {
                TrainingUma = Instantiate(oguri, TrainingPlace.transform.position, new Quaternion(0, 0, 0, 0));
                Umatype = 6;
                TrainScene.ChooseUma = 0;
                CameraLookAt.preparetolook = 1;
            }
            UmaA = TrainingUma.GetComponent<Animator>();

        }
        if (chooseNum != -1 && preparetochoose && round > 0)
        {
            preparetochoose = false;
            trainafter();
            TrainSystem(chooseNum);
            chooseNum = -1;
            Calculator();
            StartCoroutine("waitforsecond");              
        }
        else if(round == 0 && ReadytoW == 1)
        {
            ReadytoW = 0;
            LoadData = File.ReadAllText(path);
            Uma = JsonHelper.FromJson<Data>(LoadData);
            Debug.Log("Uma Loading");

            UmaData[0] = new Data();
            UmaData[1] = new Data();
            UmaData[2] = new Data();
            UmaData[3] = new Data();
            UmaData[0].type = Uma[0].type;
            UmaData[1].type = Uma[1].type;
            UmaData[2].type = Uma[2].type;
            UmaData[3].type = Uma[3].type;
            UmaData[0].AltiLevel = Uma[0].AltiLevel;
            UmaData[1].AltiLevel = Uma[1].AltiLevel;
            UmaData[2].AltiLevel = Uma[2].AltiLevel;
            UmaData[3].AltiLevel = Uma[3].AltiLevel;
            UmaData[0].Speed = Uma[0].Speed;
            UmaData[1].Speed = Uma[1].Speed;
            UmaData[2].Speed = Uma[2].Speed;
            UmaData[3].Speed = Uma[3].Speed;
            UmaData[0].Power = Uma[0].Power;
            UmaData[1].Power = Uma[1].Power;
            UmaData[2].Power = Uma[2].Power;
            UmaData[3].Power = Uma[3].Power;
            UmaData[0].Energy = Uma[0].Energy;
            UmaData[1].Energy = Uma[1].Energy;
            UmaData[2].Energy = Uma[2].Energy;
            UmaData[3].Energy = Uma[3].Energy;
            UmaData[0].Int = Uma[0].Int;
            UmaData[1].Int = Uma[1].Int;
            UmaData[2].Int = Uma[2].Int;
            UmaData[3].Int = Uma[3].Int;
            UmaData[0].UmaCount = Uma[0].UmaCount;
            UmaData[1].UmaCount = Uma[1].UmaCount;
            UmaData[2].UmaCount = Uma[2].UmaCount;
            UmaData[3].UmaCount = Uma[3].UmaCount;

            if (UmaData[2].type != 0) UmaCount = 2;
            else if (UmaData[1].type != 0) UmaCount = 1;
            else if (UmaData[0].type != 0) UmaCount = 0;
            else UmaCount = -1;

            UmaCount += 1;

            UmaData[UmaCount].type = Umatype;
            UmaData[UmaCount].AltiLevel = AltiLevel;
            UmaData[UmaCount].Speed = Intspeed;
            UmaData[UmaCount].Power = Intpower;
            UmaData[UmaCount].Energy = Intenergy;
            UmaData[UmaCount].Int = Intinte;
            UmaData[UmaCount].UmaCount = UmaCount;
            string jsonInfo = JsonHelper.ToJson(UmaData, true);
            File.WriteAllText(path, jsonInfo);
            Debug.Log("育成完成");
            TrainChat.TC.SetActive(true);
            TrainChat.C.GetComponent<Text>().text = "育成完成";          
        }
        if (TrainChat.ReturnB)
        {
            TrainLoading.loadingImage.SetActive(true);
            StartCoroutine(TrainLoading.LoadLevelWithBar("Main", TrainLoading.loadingBar));
            TrainChat.ReturnB = false;
            Restart();
        }
    }

    #region Button
    void restclick()
    {
        chooseNum = 0;
    }
    void speedclick()
    {
        chooseNum = 1;
    }
    void energyclick()
    {
        chooseNum = 2;
    }
    void powerclick()
    {
        chooseNum = 3;
    }
    void inteclick()
    {
        chooseNum = 4;
    }
    void raceclick()
    {
        chooseNum = 5;
    }
    void giveupclick()
    {
        Restart();
        TrainLoading.loadingImage.SetActive(true);
        StartCoroutine(TrainLoading.LoadLevelWithBar("Main", TrainLoading.loadingBar));
    }
    #endregion


    void trainafter()
    {
        rest.gameObject.SetActive(false);
        speed.gameObject.SetActive(false);
        energy.gameObject.SetActive(false);
        power.gameObject.SetActive(false);
        inte.gameObject.SetActive(false);
        race.gameObject.SetActive(false);
        PSpeed.SetActive(false);
        PEnergy.SetActive(false);
        PPower.SetActive(false);
        PInt.SetActive(false);
    }
    void trainbefore()
    {
        rest.gameObject.SetActive(true);
        speed.gameObject.SetActive(true);
        energy.gameObject.SetActive(true);
        power.gameObject.SetActive(true);
        inte.gameObject.SetActive(true);
        race.gameObject.SetActive(true);
        PSpeed.SetActive(true);
        PEnergy.SetActive(true);
        PPower.SetActive(true);
        PInt.SetActive(true);
        TrainingUma.transform.position = TrainingPlace.transform.position;
        TrainingUma.transform.rotation = TrainingPlace.transform.rotation;
        UmaA.Play("idle");
        CancelInvoke();
    }

    void TrainSystem(int chooseNum)
    {
        bool Success = true;

        if(chooseNum > 0 && chooseNum < 4)
        {
            if (life >= 50)
            {
                Success = true;
            }
            else if (life >= 30 && life < 50)
            {
                int r = UnityEngine.Random.Range(0, 3);
                switch (r)
                {
                    case 0:
                        Success = false;
                        break;
                    case 1:
                        Success = true;
                        break;
                    case 2:
                        Success = true;
                        break;
                }
            }
            else
            {
                int r = UnityEngine.Random.Range(0, 3);
                switch (r)
                {
                    case 0:
                        Success = false;
                        break;
                    case 1:
                        Success = true;
                        break;
                    case 2:
                        Success = false;
                        break;
                }
            }
            
        }
        if (chooseNum == 4)
        {
            if (life < 30)
            {
                int r = UnityEngine.Random.Range(0, 3);
                switch (r)
                {
                    case 0:
                        Success = false;
                        break;
                    case 1:
                        Success = true;
                        break;
                    case 2:
                        Success = true;
                        break;
                }
            }
        }
        if (Success) { 
            switch (chooseNum)
            {
                case 0:
                    TrainingUma.transform.position = room.transform.position;
                    TrainingUma.transform.rotation = room.transform.rotation;
                    UmaA.Play("sit");
                    int i;
                    int r = UnityEngine.Random.Range(0, 5);
                    if (r == 0) i = 0;
                    else if (r == 4) i = 2;
                    else i = 1;

                    if ((life + 30 + 20 * i) > 100) life = 100;
                    else life += 30 + 20 * i;
                    break;
                case 1:
                    TrainingUma.transform.position = field.transform.position;
                    TrainingUma.transform.rotation = field.transform.rotation;
                    UmaA.Play("run");
                    InvokeRepeating("Run", 0.1f, 0.1f);
                    Intspeed += pspeed;
                    Intpower += (ppower*2)/3;
                    tspeedtime += 1;
                    life -= 25 + (pspeed + ppower) / 10;
                    break;
                case 2:
                    TrainingUma.transform.position = gym.transform.position;
                    TrainingUma.transform.rotation = gym.transform.rotation;
                    UmaA.Play("sidestepL");
                    Intenergy += penergy;
                    Intinte += (pinte*2)/3;
                    tenergytime += 1;
                    life -= 25 + (penergy + pinte) / 10;
                    break;
                case 3:
                    TrainingUma.transform.position = gym.transform.position;
                    TrainingUma.transform.rotation = gym.transform.rotation;
                    UmaA.Play("punch");
                    Intpower += ppower;
                    Intenergy += (penergy*2)/3;
                    tpowertime += 1;
                    life -= 25 + (ppower + penergy) / 10;
                    break;
                case 4:
                    TrainingUma.transform.position = classroom.transform.position;
                    TrainingUma.transform.rotation = classroom.transform.rotation;
                    UmaA.Play("nod");
                    Intinte += pinte;
                    Intspeed += (pspeed*2)/3;
                    tinttime += 1;
                    life += 15 + tinttime;
                    break;
                case 5:
                    if (round >= 20)
                    {

                    }
                    else if (round >= 15 && round < 20)
                    {

                    }
                    else if (round >= 10 && round < 15)
                    {

                    }
                    else if (round >= 5 && round < 10)
                    {

                    }
                    else
                    {

                    }
                    break;
            } 
        }
        if (!Success)
        {
            life += 15;
            UmaA.Play("damage");
        }
        
    }
    void Calculator()
    {
        pspeed = 10;
        penergy = 10;
        ppower = 10;
        pinte = 10;
        for(int i = 0; i < 20; i++)
        {
            int r = UnityEngine.Random.Range(0, 4);
            switch (r)
            {
                case 0:
                    pspeed += 1;
                    break;
                case 1:
                    penergy += 1;
                    break;
                case 2:
                    ppower += 1;
                    break;
                case 3:
                    pinte += 1;
                    break;
            }
        }
        pspeed += tspeedtime;
        penergy += tenergytime;
        ppower += tpowertime;
        pinte += tinttime;
    }

    IEnumerator waitforsecond()
    {
        yield return new WaitForSeconds(2);
        preparetochoose = true;
        round -= 1;
        Round.GetComponent<Text>().text = "" + round;
        Speed.GetComponent<Text>().text = "" + Intspeed;
        Energy.GetComponent<Text>().text = "" + Intenergy;
        Power.GetComponent<Text>().text = "" + Intpower;
        Int.GetComponent<Text>().text = "" + Intinte;
        Calculator();
        trainbefore();
    }

    void Restart()
    {
        ChooseState.Camera.SetActive(true);
        round = 20;
        life = 100;
        pspeed = 15;
        penergy = 15;
        ppower = 15;
        pinte = 15;
        Intspeed = 50;
        Intenergy = 50;
        Intpower = 50;
        Intinte = 50;
        AltiLevel = 1;
        tspeedtime = 0;
        tenergytime = 0;
        tpowertime = 0;
        tinttime = 0;
        chooseNum = -1;
        ReadytoW = 1;
    }

    void Run()
    {
        TrainingUma.transform.position += new Vector3(-3, 0, 0);
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


