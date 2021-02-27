using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 lastCheckpointPos;
    public Vector3 gameStartPoint;

    public int extraJumpVal;
    public bool canDash;

    public GameObject dialogueBox;
    public GameObject dialogueText;
    private Coroutine dialogCo;

    public AudioSource deathSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        } else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        lastCheckpointPos = gameStartPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(string text)
    {
        dialogueBox.SetActive(true);
        dialogCo = StartCoroutine(TypeText(text));
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
        StopCoroutine(dialogCo);
    }


    IEnumerator TypeText(string text)
    {
        dialogueText.GetComponent<TextMeshProUGUI>().text = "";
        foreach(char c in text.ToCharArray())
        {
            dialogueText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(.03f);
        }

    }

    public void PlayerDeath(GameObject player)
    {
        deathSound.Play();
        player.transform.position = lastCheckpointPos;
        Debug.Log("'respawned' after death.");
    }




    //IEnumerator ColorLerp(Color endValue, float duration)
    //{
    //    float time = 0;
    //    Image sprite = backgroundImage.GetComponent<Image>();
    //    Color startValue = sprite.color;
    //
    //    while(time < duration)
    //    {
    //        sprite.color = Color.Lerp(startValue, endValue, time / duration);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    sprite.color = endValue;
    // }
}
