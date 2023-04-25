using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabTwo : XRGrabInteractable
{
    public Transform leftAttachPoint;
    public Transform rightAttachPoint;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftAttachPoint;
        } else if(args.interactorObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightAttachPoint;
        }
        base.OnSelectEntered(args);
    }
}