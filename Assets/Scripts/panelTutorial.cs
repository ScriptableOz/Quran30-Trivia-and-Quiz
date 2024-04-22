using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class panelTutorial : MonoBehaviour
{
    public GameObject[] images;      // Array to hold your image GameObjects
    public Button nextButton;        // Reference to the Next button
    public Button skipButton;        // Reference to the Skip button

    private int currentIndex = -1;   // Index to track the current image (-1 indicates no image is active)
    private bool allImagesShown = false; // Flag to track if all images have been shown

    void Start()
    {
        // Deactivate all images at start
        DeactivateAllImages();

        // Add listeners to the Next and Skip buttons
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextImage);
        }
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipImages);
        }
    }

    void NextImage()
    {
        // Increment the index
        currentIndex++;

        // Deactivate the previous image
        if (currentIndex > 0 && currentIndex - 1 < images.Length)
        {
            images[currentIndex - 1].SetActive(false);
        }

        // Check if we've reached the end of the images array
        if (currentIndex >= images.Length)
        {
            allImagesShown = true;
            // Hide both buttons if all images have been shown
            if (allImagesShown && nextButton != null && skipButton != null)
            {
                nextButton.gameObject.SetActive(false);
                skipButton.gameObject.SetActive(false);
            }

            // Reload the current scene
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           // return;//
        }

        // Activate the next image
        if (currentIndex < images.Length)
        {
            images[currentIndex].SetActive(true);
        }
    }

    void SkipImages()
    {
        // Deactivate all images
        DeactivateAllImages();

        // Hide both buttons
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
        }
        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(false);
        }

        // Load another scene
        //SceneManager.LoadScene("OtherSceneName");//
    }

    void DeactivateAllImages()
    {
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
    }
}
