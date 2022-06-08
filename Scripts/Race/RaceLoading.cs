using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceLoading : MonoBehaviour
{
    // Start is called before the first frame update
    static public Slider loadingBar;
    static public GameObject loadingImage;
    static public AsyncOperation _async;

    void Start()
    {
        loadingBar = GameObject.Find("loadingBar").GetComponent<Slider>();
        loadingImage = GameObject.Find("loadingImage");
        loadingImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    static public IEnumerator LoadLevelWithBar(string level, Slider loadingBar)
    {
        _async = SceneManager.LoadSceneAsync(level);
        while (!_async.isDone)
        {
            loadingBar.value = _async.progress;
            yield return null;
        }
    }
}
