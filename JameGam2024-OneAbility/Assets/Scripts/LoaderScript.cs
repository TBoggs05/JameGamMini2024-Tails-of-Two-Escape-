using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoaderScript
{
    /*
     * list of all scenes that are public and accessible anywhere.
     */
    public enum Scene
    {
        Bedroom, Hallway, Bathroom, Kitchen, LivingRoom, Attic
    }
    /*
     * load function to load to a new scene. public and can be called anywhere.
     */
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public static void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}