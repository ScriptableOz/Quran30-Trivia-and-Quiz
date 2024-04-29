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

        
        if (isDefaultButton)
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
        // Enable the outline when the button is clicked
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
