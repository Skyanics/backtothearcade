using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreen : MonoBehaviour
{

    AsyncOperation ao;
    public Image progBar;

    public bool isFakeLoadingBar = false;

    // Use this for initialization
    void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
 

        if (!isFakeLoadingBar)
        {
            StartCoroutine(LoadLevelWithRealProgress());
        }
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync(2);

        while (!ao.isDone)
        {
            progBar.fillAmount = ao.progress;

            Debug.Log(ao.progress);
            yield return null;
        }
    }
}


