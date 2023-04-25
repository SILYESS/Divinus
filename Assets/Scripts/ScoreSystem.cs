using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class ScoreSystem : MonoBehaviour
{
   [SerializeField] 
   private TMP_Text scoreText;
   public float score;
    private void Start()
    {
        //DisplayScore();
        ResetScore();

    }
    public void Scoring(float scoreRate)
    {
        score += scoreRate;
        scoreText.text = "" + score;
        PlayerPrefs.SetFloat("score",score + PlayerPrefs.GetFloat("score"));
    }

    //public void DisplayScore()
    //{
    //    Scene current = SceneManager.GetActiveScene();
    //    if (current.name == "MainMenu" && PlayerPrefs.GetFloat("score") !=0)
    //    {
    //        //finalscoreText = Find("CanvasMain/Score/scoreResult").GetComponent<TextMeshPro>();
    //        scoreCanvas.SetActive(true);
    //        finalscoreText.text = "" + PlayerPrefs.GetFloat("score");
    //    }
        
    //}
    public void ResetScore()
    {
        PlayerPrefs.SetFloat("score", 0f);
    }

}
