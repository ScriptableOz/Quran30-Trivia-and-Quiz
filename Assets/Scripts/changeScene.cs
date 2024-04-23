using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void loadScene(string sceneName)
    {
        Time.timeScale = 2.0f;
        SceneManager.LoadScene(sceneName);
    }

}
