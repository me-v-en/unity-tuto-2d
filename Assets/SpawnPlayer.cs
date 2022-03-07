using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private void Awake()
    {
        // Set the player position ot the object position
        GameObject.FindGameObjectWithTag("Player")
            .transform
            .position = transform.position;
    }

}
