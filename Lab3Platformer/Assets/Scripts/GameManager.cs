using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 lastCheckpointPos;
    public Vector3 gameStartPoint;

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
}
