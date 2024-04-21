using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class pauseHandler : MonoBehaviour
{

    public GameObject pausePanel;
    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }
    public void pauseToggle()
    {
        if (isPaused)
        {
            unPaused();
            isPaused = false;
        }

        else
        {
            Paused();
            isPaused = true;
        }
    }

    void Paused()
    {
        pausePanel.SetActive(true);
    }

    void unPaused()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void buttonUnpausedScene()
    {
        Time.timeScale = 1.0f;
    }

}
