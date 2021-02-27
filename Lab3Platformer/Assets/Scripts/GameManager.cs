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
    public int dashNumber;
    public bool canDash;

    public GameObject dialogueBox;
    public GameObject dialogueText;
    private Coroutine dialogCo;


    public string newLevel;

    public GameObject canvas;
    public GameObject events;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
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
        player.transform.position = lastCheckpointPos;
    }


    public void addJump()
    {
        if (extraJumpVal < 1)
        {
            extraJumpVal += 1;
        }
    }

}
