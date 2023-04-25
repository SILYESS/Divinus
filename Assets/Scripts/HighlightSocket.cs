using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSocket : MonoBehaviour
{

    public Material materialToHighlight;
    public Color highlightColor;
    public float highlightSpeed;

    private Color baseColor;
    private bool isHighlighting;

    private void Start()
    {
        
        materialToHighlight =GetComponent<Renderer>().material;
        baseColor = materialToHighlight.color;
    }

    private void Update()
    {
        if (isHighlighting)
        {
            float t = Mathf.PingPong(Time.time * highlightSpeed, 1f);
            materialToHighlight.color = Color.Lerp(highlightColor, baseColor, t);
        }
    }

    public void StartHighlight()
    {
        isHighlighting = true;
    }

    public void StopHighlight()
    {
        isHighlighting = false;
        materialToHighlight.color = baseColor;
    }
}
