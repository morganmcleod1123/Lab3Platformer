using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryMenu : MonoBehaviour
{
    public GameObject thisImage;
    public GameObject startImage;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton()
    {
        backButton.SetActive(false);
        StartCoroutine(ColorLerp(startImage.GetComponent<Image>().color, 1));
    }


    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = thisImage.GetComponent<Image>();
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
