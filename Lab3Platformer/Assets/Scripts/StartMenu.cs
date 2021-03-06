using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject creditButton;
    public GameObject controlsButton;

    public GameObject startImage;
    public GameObject creditImage;
    public GameObject controlImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void StartButton()
    {
        startImage.SetActive(false);
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 1));
        Debug.Log("start button pressed");
        SceneManager.LoadScene("Level 1");
    }

    public void CreditsButton()
    {
        startImage.SetActive(false);
        startButton.SetActive(false);
        creditImage.SetActive(true);
        StartCoroutine(ColorLerp(creditImage.GetComponent<Image>().color, 1));
        Debug.Log("credits button pressed.");
    }

    public void ControlsButton()
    {
        startImage.SetActive(false);
        startButton.SetActive(false);
        controlImage.SetActive(true);
        StartCoroutine(ColorLerp(controlImage.GetComponent<Image>().color, 1));
        Debug.Log("controls button pressed.");
    }


    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = startImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }
}
