using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    protected static SceneLoading instance;
    public static SceneLoading Instance => instance;

    [SerializeField] protected GameObject sceneLoading;
    [SerializeField] protected Slider slider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SceneLoad(int id)
    {
        sceneLoading.SetActive(true);
        slider.value = 0;
        StartCoroutine(LoadSceneAfterTime(id));
    }

    protected IEnumerator LoadSceneAfterTime(int id)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);
        while(!asyncOperation.isDone)
        {
            slider.value = asyncOperation.progress;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        sceneLoading.SetActive(false);
    }
}
