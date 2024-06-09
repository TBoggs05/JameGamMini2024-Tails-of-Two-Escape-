using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    private Scene currentScene;
    private string sceneName;
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
                    break;
                case "Bedroom":
                    LoaderScript.LoadLevel("Bathroom");
                    break;
                case "Bathroom":
                    LoaderScript.LoadLevel("Attic");
                    break;
                case "Attic":
                    LoaderScript.LoadLevel("EndScreen");
                    break;
            }
        }

    }
}
