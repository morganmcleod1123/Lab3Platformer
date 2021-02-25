using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checkpoint Creation Tutorial https://youtu.be/ofCLJsSUom0

public class Checkpoint : MonoBehaviour
{

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
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            GameManager.Instance.lastCheckpointPos = transform.position;
        }
    }
}
