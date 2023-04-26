using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text textCounter;
    public float timeRemaining;
    public bool timer, countdown;
    float timeCount;
    bool minuteLeft;

    private AudioManager audioManager;


    private void Start() 
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        SwitchTimer(countdown, timer);
    }
        
       void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if(timeToDisplay < 40 && !minuteLeft){
            minuteLeft = true;
            textCounter.color = Color.red;
            audioManager.Play("Clock");
        }
    }
    void LoadOtherScene(float timeToDisplay)
    {
        if (timeToDisplay == 0)
        {
            StartCoroutine(GoToSceneRoutine());
            audioManager.Stop("Clock");
        }
    }
    
    IEnumerator GoToSceneRoutine()
    {
        //what happens when the time ends
        FindObjectOfType<SpawnManager>().enabled = false;
        yield return new WaitForSeconds(1f);

    }
    public void SwitchTimer(bool countdown, bool timer)
    {
        //timeCount = 0;
        switch (true)
        {
            case true when countdown:
                DisplayTime(timeRemaining);
                LoadOtherScene(timeRemaining);
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;

                }

                else
                {
                    timeRemaining = 0;
                }
                break;
            case true when timer:
                timeCount += Time.deltaTime;
                DisplayTime(timeCount);
                LoadOtherScene(timeCount);
                break;
            default:
                break;
        }
    }
}
