using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTracker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.tag == "Player")
        {
            FindObjectOfType<ScoreSystem>().Damage(1);


        }
        else if(other.tag == "Sword")
        {
            FindObjectOfType<ScoreSystem>().Scoring(1);

        }
    }
}
