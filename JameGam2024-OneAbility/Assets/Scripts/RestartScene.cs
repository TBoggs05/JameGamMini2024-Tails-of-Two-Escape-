using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private Scene currentScene;
    private string sceneName;
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (SceneManager.GetActiveScene().name == "StartScreen")
            audioManager.Play("StartScreen");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;
                    LoaderScript.LoadLevel(sceneName);
                    audioManager = FindObjectOfType<AudioManager>();
                    audioManager.Stop(sceneName);
                    audioManager.Play(sceneName);
        }

    }
}

