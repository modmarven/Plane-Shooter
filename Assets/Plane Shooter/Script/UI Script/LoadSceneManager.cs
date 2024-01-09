using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    
    public GameObject loadingManager;
    public Slider progressSlider;

    public float loadSpeed = 0.02f;

    public void LoadScene(int index)
    {
        StartCoroutine(LoadingProgress(index));
    }

    public IEnumerator LoadingProgress(int index)
    {
        progressSlider.value = 0;
        loadingManager.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        float progress = progressSlider.value;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime * loadSpeed);
            progressSlider.value = progress;

            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

}
