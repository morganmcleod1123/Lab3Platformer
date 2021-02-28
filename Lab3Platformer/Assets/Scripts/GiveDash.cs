using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.canDash = true;
            GameManager.Instance.dashNumber = 1;
        }
    }
}
