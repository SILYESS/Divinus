using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    GameObject playerPos;
    [SerializeField] float targetSpeed;
    private void Start() 
    {
        if (playerPos == null)
        {
            //playerPos = GameObject.FindWithTag("Player");

        }
    }
    private void Update() 
    {
        MoveTarget();    
    }
    void MoveTarget()
    {
        Vector3 targetDirection = Camera.main.transform.position - transform.position;
        transform.Translate(targetDirection * targetSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            FindObjectOfType<ScoreSystem>().Damage(1);
            Destroy(gameObject);


        }
        else if (other.tag == "Sword")
        {
            FindObjectOfType<ScoreSystem>().Scoring(1);
        }
    }
}
