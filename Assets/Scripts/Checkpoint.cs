using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;
    private bool isActive = true;

    void Awake()
    {
        Debug.Log("Awake Ckeckpoint");
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            Debug.Log("Checkpoint inactive");
            return;
        }
        Debug.Log("OnCollisionEnter");
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("OnCollisionEnter Player");
            playerSpawn.position = transform.position;
            isActive = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
        
    }
}
