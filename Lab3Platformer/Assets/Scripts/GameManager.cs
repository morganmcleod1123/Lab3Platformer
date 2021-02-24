using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checkpoint Creation Tutorial https://youtu.be/ofCLJsSUom0

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector2 lastCheckpointPos;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
