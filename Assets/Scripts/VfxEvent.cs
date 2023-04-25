using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class VfxEvent : MonoBehaviour
{
    [SerializeField] UnityEvent vfxAppear;
    [SerializeField] UnityEvent vfxDisappear;
    //public GameObject vfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            vfxAppear.Invoke();

        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            vfxDisappear.Invoke();
        }
    }

}
