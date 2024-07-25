using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignButton : MonoBehaviour
{
    public SceneManagerScript sceneManager;
    public string sceneName;

    private void OnMouseDown()
    {
        sceneManager.SetScene(sceneName);
    }
}
