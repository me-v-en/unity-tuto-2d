using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);

            // Respawn the player
            collision.transform.position = playerSpawn.position;
        }
    }
}
