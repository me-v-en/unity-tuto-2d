using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
            StartCoroutine(TriggerSceneLoad());
        }
    }

    private IEnumerator TriggerSceneLoad()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(sceneName);
    }
}
