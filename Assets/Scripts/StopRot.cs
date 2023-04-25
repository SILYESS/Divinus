using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StopRot : MonoBehaviour
{
    public HighlightSocket highlight;
    public GameObject rotObj;
    // Start is called before the first frame update
    private void Start()
    {
        //highlight = GetComponent<HighlightSocket>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            rotObj.GetComponent<RotateObjects>().enabled = false;
            highlight.StartHighlight();
        }


    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player")
        {
            rotObj.GetComponent<RotateObjects>().enabled = true;
            highlight.StopHighlight();   
        }
        
    }

}
