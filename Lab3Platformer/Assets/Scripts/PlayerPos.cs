using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameManager.Instance.lastCheckpointPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
