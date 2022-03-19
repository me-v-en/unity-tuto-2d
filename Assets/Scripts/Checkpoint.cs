using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;

    void Awake()
    {
        Debug.Log("Awake Ckeckpoint");
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("OnCollisionEnter Player");
            playerSpawn.position = transform.position;
        }
        
    }
}
