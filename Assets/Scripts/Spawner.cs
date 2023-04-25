using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{
    public event Action OnAvatarLoadComplete;

    public GameObject[] avatars;
    public GameObject[] positionsSpawn;
    private bool avatarsSpawnedHere = false;

    private void Start()
    {
        StartCoroutine(SpawnAvatars());


    }
    private IEnumerator SpawnAvatars()
    {
        // Spawn the avatars
        for (int i = 0; i < avatars.Length; i++)
        {
            GameObject loadedAvatar = Resources.Load<GameObject>(avatars[i].name);

            if (loadedAvatar != null)
            {
                GameObject spawnedAvatar = Instantiate(loadedAvatar, positionsSpawn[i].transform.position, positionsSpawn[i].transform.rotation);
                spawnedAvatar.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
        }
        avatarsSpawnedHere=true;
        PlayerPrefs.SetInt("avatarsSpawned", avatarsSpawnedHere ? 1 : 0);
    }


}
//void Start()
//{
//    // Start loading the next scene
//    LoadNextSceneAsync();
//}
//public IEnumerator LoadNextSceneAsync()
//{
//       // If the avatars haven't been spawned yet and the scene is almost fully loaded, spawn the avatars
//        if (!avatarsSpawned)
//        {
//            // Spawn the avatars...
//             for (int i = 0; i < avatars.Length; i++)
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

//            //            // Trigger the OnAvatarLoadComplete event
//            if (OnAvatarLoadComplete != null)
//            {
//                OnAvatarLoadComplete();
//            }
//        }

//        yield return null;
//    }
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

//            // Trigger the OnAvatarLoadComplete event
//            if (OnAvatarLoadComplete != null)
//            {
//                OnAvatarLoadComplete();
//            }
//        }

//        yield return null;
//    }
//}
