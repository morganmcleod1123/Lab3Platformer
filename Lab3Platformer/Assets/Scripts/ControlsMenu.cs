using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsImage;
    public GameObject startImage;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void BackButton()
    {
        controlsImage.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("back button pressed");
    }


    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;

        Image sprite = controlsImage.GetComponent<Image>();
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
