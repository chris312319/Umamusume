using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DormitorySwitch : MonoBehaviour
{
    string LoadData;
    public Data[] Uma;
    string path = Application.streamingAssetsPath + "/Umafile";
    bool enter = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enter && Input.GetKeyDown(KeyCode.Space) && !ChatBox.CBExist)
        {
            LoadData = File.ReadAllText(path);
            Uma = JsonHelper.FromJson<Data>(LoadData);
            if (Uma[0].type != 0)
            {
                MainLoading.loadingImage.SetActive(true);
                StartCoroutine(MainLoading.LoadLevelWithBar("Dormitory", MainLoading.loadingBar));
                enter = false;
            }
            else
            {
                ChatBox.Chat.GetComponent<Text>().text = "宿舍為空";
                ChatBox.CB.SetActive(true);
                ChatBox.CBExist = true;
            }
        }
    }

   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Dormitory");
    }
}
