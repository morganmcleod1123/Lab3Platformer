using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{

    public string newLevel;
    public int spawnX;
    public int spawnY;
    public int spawnZ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
            GameManager.Instance.lastCheckpointPos = new Vector3(spawnX, spawnY, spawnZ);
        }
    }

}
