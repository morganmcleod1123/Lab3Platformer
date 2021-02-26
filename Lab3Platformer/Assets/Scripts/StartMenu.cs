using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        startButton.SetActive(false);
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 4));
        // MOVE TO LEVEL 1 SCENE
    }

    public void CreditsButton()
    {
        startButton.SetActive(false);
        StartCoroutine(ColorLerp(creditImage.GetComponent<Image>().color, 1));
    }

    public void ControlsButton()
    {
        startButton.SetActive(false);
        StartCoroutine(ColorLerp(controlImage.GetComponent<Image>().color, 1));
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
