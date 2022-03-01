using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        destPoint = 0;
        target = waypoints[destPoint];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;

        MoveEnnemy(dir);
        UpdateWaypoint();

        FlipPlayer(dir.x);
    }

    void MoveEnnemy(Vector3 _dir)
    {

        transform.Translate(_dir.normalized * speed * Time.deltaTime, Space.World);
    }

    void UpdateWaypoint()
    {
        // Si l'ennemi est presque arrivé au point, passe au point suivant
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }

    void FlipPlayer(float _xDir)
    {
        if (_xDir > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_xDir < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
