using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        App.loader = this;
    }
    private void Start()
    {
        LoadScene("Menu",true);
    }
    public void LoadScene(string sceneName, bool setActive = false)
    {
        StartCoroutine(LoadSceneCorontine(sceneName,setActive));
    }
    public void UnloadScene(string sceneName)
    {
        StartCoroutine(UnloadSceneCorontine(sceneName));
    }
    private IEnumerator LoadSceneCorontine(string sceneName, bool setActive)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress>=0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
        if(setActive)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
    private IEnumerator UnloadSceneCorontine(string sceneName)
    {
        AsyncOperation async = SceneManager.UnloadSceneAsync(sceneName);
        while(!async.isDone)
        {
            yield return null;
        }
    }
}
