using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    private Scene currentScene;
    private string sceneName;
    private AudioManager audioManager;
    private void Awake()
    {
    audioManager = FindObjectOfType<AudioManager>();
        if(SceneManager.GetActiveScene().name == "StartScreen")
       audioManager.Play("StartScreen");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;
            switch (sceneName)
            {
                case "StartScreen":
                    LoaderScript.LoadLevel("Bedroom");
                    audioManager = FindObjectOfType<AudioManager>();
                    audioManager.Stop("StartScreen");
                    audioManager.Play("Bedroom");
                    break;
                case "Bedroom":
                    LoaderScript.LoadLevel("Bathroom");
                    audioManager = FindObjectOfType<AudioManager>();
                    audioManager.Stop("Bedroom");
                    audioManager.Play("Bathroom");
                    break;
                case "Bathroom":
                    audioManager.Stop("Bathroom");
                    LoaderScript.LoadLevel("Attic");
                    audioManager = FindObjectOfType<AudioManager>();
                    audioManager.Play("Attic");
                    break;
                case "Attic":
                    audioManager.Stop("Attic");
                    LoaderScript.LoadLevel("EndScreen");
                    audioManager = FindObjectOfType<AudioManager>();
                    audioManager.Play("StartScreen");
                    break;
            }
        }

    }
}
