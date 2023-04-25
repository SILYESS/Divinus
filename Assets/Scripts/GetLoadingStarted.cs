using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLoadingStarted : MonoBehaviour
{
    public GameObject loadingScreens;

    private bool sceneLoaded = false;
    //private void Start()
    //{
    //    //// Start loading the Dougga scene in the background
    //    //SceneManager.LoadSceneAsync("Dougga", LoadSceneMode.Additive);
    //}
    private void Start()
    {
        
        LoadAsync();
        SceneManager.LoadSceneAsync("Dougga", LoadSceneMode.Additive);
    }
    private void Update()
    {

        // Check if the Dougga scene is loaded and the avatars haven't been spawned yet
        if (SceneManager.GetSceneByName("Dougga").isLoaded )
        {
            // Spawn the avatars in the background
            //StartCoroutine(SpawnAvatars());
            Debug.Log("loaded");
        }

        // Check if the Dougga scene is fully loaded and activate the "Continue" button
        if (SceneManager.GetSceneByName("Dougga").isLoaded && PlayerPrefs.GetInt("avatarsSpawned") == 1)
        {
            Debug.Log("start");
            loadingScreens = GameObject.Find("XROrigin/Camera Offset/Main Camera/CanvasMain");
            loadingScreens.SetActive(false);
        }
    }
    

    IEnumerator LoadAsync()
    {
        // Load the Dougga scene asynchronously
        AsyncOperation douggaLoad = SceneManager.LoadSceneAsync("Dougga");
        douggaLoad.allowSceneActivation = false;
        // Wait until the Dougga scene is almost fully loaded
        while (douggaLoad.progress < 0.9f)
        {
            
            yield return null;
        }

        // Allow the Dougga scene to be activated
        douggaLoad.allowSceneActivation = true;

        // Wait until the Dougga scene is fully loaded
        yield return douggaLoad;
    }
}
    //IEnumerator StartGameFn()
    //{
    //    // Load the loading screen scene asynchronously
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoadingScreen");
    //    asyncLoad.allowSceneActivation = false;

    //    // Wait until the loading screen is fully loaded
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }

    //    // Load the Dougga scene asynchronously
    //    AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Dougga");
    //    asyncLoad2.allowSceneActivation = false;

    //    // Wait until the Dougga scene is fully loaded
    //    while (!asyncLoad2.isDone)
    //    {
    //        yield return null;
    //    }

    //    // Activate the Dougga scene
    //    asyncLoad2.allowSceneActivation = true;
    //}