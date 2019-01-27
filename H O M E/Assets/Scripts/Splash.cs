using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public AudioSource introSound;
    public AudioSource introSound2;


    AsyncOperation async;
    void Start()
    {
        StartCoroutine(LoadLoop());
    }
    
    IEnumerator LoadLoop() {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        yield return async;
     }
 
    public void ActivateScene() {
        async.allowSceneActivation = true;
    }

    public void PlayIntroSound()
    {
        introSound.Play();
    }
    public void PlayIntroSound2()
    {
        introSound2.Play();
    }
}
