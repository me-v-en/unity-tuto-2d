
using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] gameObjects;
    void Awake()
    {
        foreach(var gameObject in gameObjects)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
