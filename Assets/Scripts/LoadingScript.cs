using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScript : MonoBehaviour
{
    public GameObject loaderUI;
    public Image LoadingBarFill;
    public Slider progressSlide;
    // Start is called before the first frame update
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public IEnumerator LoadSceneAsync(int scenceId)
    {
        progressSlide.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scenceId);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlide.value = progress;
            if (progress >= 0.9f)
            {
                progressSlide.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
        }

        yield return null;
    }

}
