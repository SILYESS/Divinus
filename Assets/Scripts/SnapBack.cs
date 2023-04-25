using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBack : MonoBehaviour
{
    Vector3 initialPos;
    Quaternion initialRot;

    float holdTimer;

    bool released, isHeld;

    private void Start()
    {
        initialPos = this.transform.position;
        initialRot = this.transform.rotation;

        released = false;
    }

    private void Update()
    {
        if(released)
        {
            holdTimer += Time.deltaTime;

            if(holdTimer >= 10f)
            {
                //Possibly play SFX?
                transform.position = initialPos;
                transform.rotation = initialRot;

                holdTimer = 0f;
                released = false;
            }
        }
    }

    public void ResetTimer()
    {
        holdTimer = 0f;
        released = false;
    }

    public void CheckReleased()
    {
        released = true;
    }
}
