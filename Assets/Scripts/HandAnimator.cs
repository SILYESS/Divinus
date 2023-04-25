using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public Animator anim;
    public InputActionProperty pinch;
    public InputActionProperty grip;
    private void Update() 
    {
        float pinchValue = pinch.action.ReadValue<float>();
        float gripValue = grip.action.ReadValue<float>();

        anim.SetFloat("Grip", gripValue);
        anim.SetFloat("Trigger", pinchValue);    
    }

}
