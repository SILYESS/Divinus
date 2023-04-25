using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    //public GameObject continueButton;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Spawner AvatarManager = FindObjectOfType<Spawner>();
    //    AvatarManager.OnAvatarLoadComplete += OnAvatarLoadComplete;
    //}

    //void OnAvatarLoadComplete()
    //{
    //    // Show the "Continue" button
    //    continueButton.SetActive(true);
    //}
}


    //public GameObject[] avatars;
    //public GameObject[] positionsSpawn;
    //public GameObject continueButton;

    //private bool avatarsSpawned = false;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    // Start loading the next scene
    //    StartCoroutine(LoadNextSceneAsync());
    //}

    //IEnumerator LoadNextSceneAsync()
    //{
    //    // Load the next scene asynchronously
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Dougga");
    //    asyncLoad.allowSceneActivation = false;

    //    // Wait until the scene is fully loaded
    //    while (!asyncLoad.isDone)
    //    {
    //        // If the avatars haven't been spawned yet and the scene is almost fully loaded, spawn the avatars
    //        if (!avatarsSpawned && asyncLoad.progress >= 0.9f)
    //        {
    //            // Spawn the avatars
    //            for (int i = 0; i < avatars.Length; i++)
    //            {
    //                GameObject loadedAvatar = Resources.Load<GameObject>(avatars[i].name);

    //                if (loadedAvatar != null)
    //                {
    //                    GameObject spawnedAvatar = Instantiate(loadedAvatar, positionsSpawn[i].transform.position, positionsSpawn[i].transform.rotation);
    //                    spawnedAvatar.SetActive(true);
    //                }
    //                yield return new WaitForSeconds(1f);
    //            }

    //            // Set the flag to indicate that the avatars have been spawned
    //            avatarsSpawned = true;
    //        }

    //        yield return null;
    //    }

    //    // Show the "Continue" button and wait for the user to click it
    //    continueButton.SetActive(true);

    //    while (!asyncLoad.allowSceneActivation)
    //    {
    //        yield return null;
    //    }

    //    // Unload the loading scene to free up memory
    //    SceneManager.UnloadSceneAsync("LoadingScreen");
    //}
