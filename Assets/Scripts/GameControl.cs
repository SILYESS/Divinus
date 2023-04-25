using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public bool isGameActive = false;
    public GameObject canvas;
    private void Update() 
    {
        if(isGameActive)
        {
            transform.Translate(-transform.up * Time.deltaTime * 10);
        }    
    }
    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.CompareTag("Sword"))
        {
            isGameActive = true;
            canvas.SetActive(true);
        }
    }
}
