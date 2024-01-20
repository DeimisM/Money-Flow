using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoadName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoadName);
    }
}
