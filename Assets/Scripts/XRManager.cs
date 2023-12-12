using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class XRManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ChangeScene(GameObject nextScene) {
        GameObject actualScene = FindObjectOfType<VideoPlayer>().gameObject;
        StartCoroutine(Fade(actualScene, nextScene));
    }

    public IEnumerator Fade(GameObject actualScene, GameObject nextScene) {
        animator.SetBool("Fade", true);
        yield return new WaitForSeconds(2.2f);
        actualScene.SetActive(false);
        transform.position = nextScene.transform.position;
        nextScene.SetActive(true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Fade", false);
    }
}
