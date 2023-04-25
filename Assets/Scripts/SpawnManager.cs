using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public List<GameObject> target;
   public List<Transform> spawnPos;
   public GameControl gameControl;
   [SerializeField] float spawnRate;
   [SerializeField] int startGame = 0;
   private void Start() 
   {
        gameControl = FindObjectOfType<GameControl>();
        StartCoroutine(StartSpawn()); 
   }
   private void Update() 
   {
    if(gameControl.GetComponent<GameControl>().isGameActive)
    {
        startGame = 1;
    }
   }
    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index], GenerateSpawnPos(), transform.rotation);
        }
    }
    IEnumerator StartSpawn()
    {
        yield return new WaitUntil(() => startGame > 0);
        yield return StartCoroutine(SpawnTarget());
    }
   private Vector3 GenerateSpawnPos()
    {
        int index = Random.Range(0,spawnPos.Count);
        Vector3 spawnPosition = spawnPos[index].position;
        return spawnPosition;
    }  
}
