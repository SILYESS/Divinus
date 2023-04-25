using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketScoring : MonoBehaviour
{
    private ScoreSystem sc;

    // Start is called before the first frame update
    private void Start()
    {
        sc = FindObjectOfType<ScoreSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ClothGrab")
        {

            sc.Scoring(1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ClothGrab")
        {
            sc.Scoring(-1);
        }

    }
}
