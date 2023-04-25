using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    public GameObject playerPos;
    [SerializeField] float targetSpeed;
    private void Start() 
    {
        if (playerPos == null)
        {   
            playerPos = GameObject.FindWithTag("Player");
        }
    }
    private void Update() 
    {
        MoveTarget();    
    }
    
    void MoveTarget()
    {
        Vector3 targetDirection = playerPos.transform.position - transform.position;
        transform.Translate(targetDirection * targetSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject); 
    }    
}
