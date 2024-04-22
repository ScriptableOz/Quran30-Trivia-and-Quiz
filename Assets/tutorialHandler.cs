using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialHandler : MonoBehaviour
{
    public GameObject tutorMenu;
    public GameObject[] tutorialPanels;
    private int currentPanelIndex = 0;

    private void Awake()
    {
        // Check if the panel has been loaded before
        if (!PlayerPrefs.HasKey("PanelLoadedKey"))
        {
            // If not loaded before, activate the panel and set the flag
            tutorMenu.SetActive(true);
            PlayerPrefs.SetInt("PanelLoadedKey", 1);
        }
        else
        {
            // If already loaded before, deactivate the panel
            tutorMenu.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate all tutorial panels except the first one
        for (int i = 1; i < tutorialPanels.Length; i++)
        {
            tutorialPanels[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Ensure only the current panel is active
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            tutorialPanels[i].SetActive(i == currentPanelIndex);
        }
    }

    // Event handler for the continue button click
    public void OnContinueButtonClick()
    {
        // Increment the current panel index
        currentPanelIndex++;

        // If all panels have been shown, reset to the first panel
        if (currentPanelIndex >= tutorialPanels.Length)
        {
            tutorMenu.SetActive(false);
        }
    }

    public void OnSkipButtonClick()
    {
        tutorMenu.SetActive(false);
    }

}

