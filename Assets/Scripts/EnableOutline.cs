using UnityEngine;
using UnityEngine.UI;

public class ThemeButton : MonoBehaviour
{
    public Outline outline;
    public Button button;
    public bool isDefaultButton = false;

    void Start()
    {
        outline = GetComponent<Outline>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClickButton);

        // Enable outline based on whether this is the default or selected theme button
        if (isDefaultButton || PlayerPrefs.HasKey("SelectedThemeButton") && PlayerPrefs.GetString("SelectedThemeButton") == gameObject.name)
        {
            EnableOutline();
        }
        else
        {
            DisableOutline();
        }
    }

    void OnClickButton()
    {
        // Save the selected theme button
        PlayerPrefs.SetString("SelectedThemeButton", gameObject.name);

        // Enable the outline 
        EnableOutline();

        // Disable the outline for other buttons
        DisableOutlineForOtherButtons();
    }

    void EnableOutline()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    void DisableOutline()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    void DisableOutlineForOtherButtons()
    {
        ThemeButton[] themeButtons = FindObjectsOfType<ThemeButton>();

        foreach (ThemeButton otherButton in themeButtons)
        {
            if (otherButton == this)
                continue;

            // Disable outline for other buttons
            otherButton.DisableOutline();
        }
    }
}
