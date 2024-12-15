using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomQuoteOfTheDay : MonoBehaviour
{
    public TextMeshProUGUI quoteText;
    public string[] quotes;
    public float displayTime;
    public float intervalTime;
    public float fadeInTime;
    public float fadeOutTime;
    
    private CanvasGroup canvasGroup;
    private float fadeStartTime;

    void Start()
    {
        canvasGroup = quoteText.GetComponent<CanvasGroup>();

        InvokeRepeating("DisplayRandomQuote", 0f, intervalTime);
    }

    void DisplayRandomQuote()
    {
        int randomIndex = Random.Range(0, quotes.Length);
        quoteText.text = quotes[randomIndex];

        canvasGroup.alpha = 0f;

        RectTransform rectTransform = quoteText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(Random.Range(-300f, 300f), Random.Range(-200f, 200f));

        quoteText.enabled = true;

        fadeStartTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - fadeStartTime;

        //fading in
        if (elapsedTime < fadeInTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
        }

        //fading out
        else if (elapsedTime < fadeInTime + displayTime)
        {
            canvasGroup.alpha = 1f;
        }

        //done fading out, disable text
        else if (elapsedTime < fadeInTime + displayTime + fadeOutTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, (elapsedTime - (fadeInTime + displayTime)) / fadeOutTime);
        }

        else
        {
            canvasGroup.alpha = 0f;
         
            quoteText.enabled = false;
        }
    }
}
