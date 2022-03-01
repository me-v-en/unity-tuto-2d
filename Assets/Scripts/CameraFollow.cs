
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    private Vector3 posOffset = new Vector3(0f, 2f, -10f);
    private Vector3 velocity;
    public float timeOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.transform.position + posOffset;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, timeOffset);
        
    }
}
