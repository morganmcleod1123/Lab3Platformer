using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public string myText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("starting dialog");
            GameManager.Instance.StartDialogue(myText);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.HideDialogue();
    }
}
