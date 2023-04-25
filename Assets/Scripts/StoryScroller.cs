using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StoryScroller : MonoBehaviour
{
    //[SerializeField] private TMP_Text storyText;
    //public float scrollSpeed = 10f;
    //public float delayBeforeScroll = 5f;
    //private bool isScrolling = false;
    //private bool isScrollComplete = false;
    //[SerializeField] private GameObject buttonLevel;
    void Start()
    {
        AudioManager.instance.Play("StoryTTS");
        //Invoke("StartScrolling", delayBeforeScroll);
    }

    //void StartScrolling()
    //{
    //    isScrolling = true;
    //    AudioManager.instance.Play("StoryTTS");

    //}

    //void Update()
    //{
    //    if (isScrolling)
    //    {
    //        storyText.rectTransform.position += Vector3.up * scrollSpeed * Time.deltaTime;
            
    //        //// Check if the story text has finished scrolling
    //        //if (storyText.pageToDisplay >= storyText.textInfo.pageCount)
    //        //{
    //        //    isScrolling = false;
    //        //    buttonLevel.SetActive(true); // Activate the button game object
    //        //}
    //    }

    //}
}
