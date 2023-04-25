using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed, vertSpeed, maxHeight, rotDegrees,yValue;
    public bool yAxis, zAxis, xAxis;
    Vector3 initialPos;
    float rotationAngle;

    private void Start() {
        initialPos = transform.position;

    }
    
    private void Update() {
        transform.position = new Vector3(initialPos.x, Mathf.Sin(Time.time * vertSpeed) * maxHeight * -1f + initialPos.y, initialPos.z);
        SwitchAxes(xAxis, yAxis,zAxis);
        
        //transform.eulerAngles = new Vector3(0f, Mathf.Sin(Time.time * rotSpeed) * rotDegrees, 0f);    
    }
    public void SwitchAxes(bool xAxis, bool yAxis, bool zAxis)
    {
        rotationAngle = Mathf.Sin(Time.time * rotSpeed) * rotDegrees;
        switch (true)
        {
            case true when xAxis:
                transform.eulerAngles = new Vector3(rotationAngle, 0f, 0f);
                break;
            case true when yAxis:
                transform.eulerAngles = new Vector3(yValue, rotationAngle, 0f);
                break;
            case true when zAxis:
                transform.eulerAngles = new Vector3(0f, 0f, rotationAngle);
                break;
            default:
                break;
        }
    }

}
